using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Drawing; // add this
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal.X307.AppBase;


namespace BatchDataProcess
{
    class Program : AppBase
    {
        static void Main(string[] args)
        {
            //GenerateBarcodeForAllMember(); //We dont generate bar code here anymore, barcode is generated everytime a report is generated
            GenerateColorCode();
            GenerateZoneAccessColorCode();
        }

        private static void GenerateColorCode()
        {
            BatchDataProcessBF bf = new BatchDataProcessBF();
            BatchDataProcessBF da = new BatchDataProcessBF();
            BatchDataProcessDS ds = new BatchDataProcessDS();

            ds = bf.GetAllColorCode();

            foreach( BatchDataProcessDS.ColorCodeRow row in ds.ColorCode)
            {
                double C = 0, M = 0, Y = 0, K = 0;
                double R = 0, G = 0, B = 0;

                C = row.ColorC / 100.00;
                M = row.ColorM / 100.00;
                Y = row.ColorY / 100.00;
                K = row.ColorK / 100.00;

                R = 255 * (1.00 - C) * (1.00 - K);
                G = 255 * (1.00 - M) * (1.00 - K);
                B = 255 * (1.00 - Y) * (1.00 - K);

                var brush = new SolidBrush(Color.FromArgb(255, Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));

                System.Drawing.Image resultImage = new Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                using (Graphics grp = Graphics.FromImage(resultImage))
                {
                    grp.FillRectangle(brush, 0, 0, 1181, 500);
                }

                ImageConverter converter = new ImageConverter();
                byte[] result = (byte[])converter.ConvertTo(resultImage, typeof(byte[]));

                row.ColorImage = result;

                da.UpdateColorCode(row);
            }
        }

        private static void GenerateZoneAccessColorCode()
        {
            BatchDataProcessBF bf = new BatchDataProcessBF();
            BatchDataProcessBF da = new BatchDataProcessBF();
            BatchDataProcessDS ds = new BatchDataProcessDS();

            ds = bf.GetAllZoneAccessColorCode();

            foreach (BatchDataProcessDS.ColorCodeRow row in ds.ColorCode)
            {
                int C = 0, M = 0, Y = 0, K = 0;
                int R = 0, G = 0, B = 0;

                C = row.ColorC;
                M = row.ColorM;
                Y = row.ColorY;
                K = row.ColorK;

                R = 255 * (1 - C) * (1 - K);
                G = 255 * (1 - M) * (1 - K);
                B = 255 * (1 - Y) * (1 - K);

                var brush = new SolidBrush(Color.FromArgb(255, (byte)R, (byte)G, (byte)B));

                System.Drawing.Image resultImage = new Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                using (Graphics grp = Graphics.FromImage(resultImage))
                {
                    grp.FillRectangle(brush, 0, 0, 1181, 500);
                }

                ImageConverter converter = new ImageConverter();
                byte[] result = (byte[])converter.ConvertTo(resultImage, typeof(byte[]));

                row.ColorImage = result;

                da.UpdateZoneAccessColorCode(row);
            }
        }

        private static void GenerateBarcodeForAllMember()
        {
            BatchDataProcessDS memberDS = new BatchDataProcessDS();
            BatchDataProcessBF bf = new BatchDataProcessBF();

            memberDS = bf.GetAllMember();

            foreach (BatchDataProcessDS.UserDetailRow row in memberDS.UserDetail)
            {
                byte[] result = GenerateBarcodeWithTransparentBackground(row.MemberID.ToString().PadLeft(10, '0'));
                row.BarCodeImage = result;

                bf.UpdateMember(row);
            }
        }

        private static byte[] GenerateBarcode(string serialNum)
        {
            ImageConverter converter = new ImageConverter();
            Bitmap barcode = new Bitmap(1, 1);
            barcode = CreateBarcode("*" + serialNum + "*"); //note that the number must be wrapped with '*'

            byte[] result = (byte[])converter.ConvertTo(barcode, typeof(byte[]));

            return result;
        }

        private static byte[] GenerateBarcodeWithTransparentBackground(string serialNum)
        {
            MemoryStream ms = new MemoryStream();
            ms = CreateBarcodeWithTransparentBackground("*" + serialNum + "*"); //note that the number must be wrapped with '*'

            byte[] result = ms.ToArray();

            return result;
        }

        // copy and paste completely
        private static Bitmap CreateBarcode(string data)
        {
            Bitmap barcode = new Bitmap(1, 1);

            Font threeOfNine = new Font("Free 3 of 9", 60, FontStyle.Regular, GraphicsUnit.Point);

            Graphics graphics = Graphics.FromImage(barcode);

            SizeF dataSize = graphics.MeasureString(data, threeOfNine);
            barcode = new Bitmap(barcode, dataSize.ToSize());
            graphics = Graphics.FromImage(barcode);
            graphics.Clear(Color.White);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            graphics.DrawString(data, threeOfNine, new SolidBrush(Color.Black), 0, 0);
            graphics.Flush();
            threeOfNine.Dispose();
            graphics.Dispose();

            return barcode;
        }

        // copy and paste completely
        private static MemoryStream CreateBarcodeWithTransparentBackground(string data)
        {
            Bitmap barcode = new Bitmap(1, 1);

            Font threeOfNine = new Font("Free 3 of 9", 60, FontStyle.Regular, GraphicsUnit.Point);

            Graphics graphics = Graphics.FromImage(barcode);

            SizeF dataSize = graphics.MeasureString(data, threeOfNine);
            barcode = new Bitmap(barcode, dataSize.ToSize());
            graphics = Graphics.FromImage(barcode);
            graphics.Clear(Color.White);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            graphics.DrawString(data, threeOfNine, new SolidBrush(Color.Black), 0, 0);
            graphics.Flush();
            threeOfNine.Dispose();
            graphics.Dispose();

            barcode.MakeTransparent(Color.White);

            MemoryStream memStream = new MemoryStream();

            barcode.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);

            return memStream;
        }
    }
}
