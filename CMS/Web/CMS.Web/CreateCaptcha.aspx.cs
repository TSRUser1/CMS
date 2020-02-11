using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

using SEM.CMS.CL.AR.Common;

namespace SEM.CMS.Web
{
    public partial class CreateCaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateCaptchaImage();
            }
        }

        #region Captcha
        /// <summary>
        /// method for create captcha image
        /// </summary>
        private void CreateCaptchaImage()
        {
            string code = string.Empty;
            switch (Request.QueryString["Page"].ToString())
            {
                case "master":
                    break;
                case "register":
                    break;
                case "login":
                    if (Request.QueryString["New"].ToString() != "0")
                    {
                        code = GetRandomText("login");
                    }
                    else
                    {
                        code = Session[WebBase.SESSION_CAPTCHACODE_LOGIN].ToString();
                    }
                    break;
            }


            //Bitmap bitmap = new Bitmap(200, 60, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Bitmap bitmap = new Bitmap(60, 20, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Bitmap bitmap = new Bitmap(45, 23, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black);
            //Rectangle rect = new Rectangle(0, 0, 200, 60);
            //Rectangle rect = new Rectangle(0, 0, 60, 20);
            Rectangle rect = new Rectangle(0, 0, 45, 30);

            //SolidBrush BackgroundColor = new SolidBrush(Color.CornflowerBlue);
            SolidBrush BackgroundColor = new SolidBrush(Color.Black);
            SolidBrush FontColor = new SolidBrush(Color.Gray);

            int counter = 0;

            g.DrawRectangle(pen, rect);
            g.FillRectangle(BackgroundColor, rect);

            for (int i = 0; i < code.Length; i++)
            {
                //g.DrawString(code[i].ToString(), new Font("Tahoma", 2 + rand.Next(7, 12), FontStyle.Italic), black, new PointF(1 + counter, 1));
                //g.DrawString(code[i].ToString(), new Font("Tahoma", 14, FontStyle.Bold), FontColor, new PointF(0 + counter, 0));
                //g.DrawString(code[i].ToString(), new Font("Arial", 9), FontColor, new PointF(5 + counter, 8));
                g.DrawString(code[i].ToString(), new Font("Arial", 9), FontColor, new PointF(5 + counter, rand.Next(4, 9)));
                counter += 8;
            }

            //DrawRandomLines(g);
            bitmap.Save(Response.OutputStream, ImageFormat.Gif);

            g.Dispose();
            bitmap.Dispose();

        }
        /// <summary>
        /// Method for drawing lines
        /// </summary>
        /// <param name="g"></param>
        /// 
        private Random rand = new Random();

        private void DrawRandomLines(Graphics g)
        {
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            for (int i = 0; i < 20; i++)
            {
                g.DrawLines(new Pen(yellow, 1), GetRandomPoints());
            }

        }

        /// <summary>
        /// method for gettting random point position
        /// </summary>
        /// <returns></returns>
        private Point[] GetRandomPoints()
        {
            Point[] points = { new Point(rand.Next(0, 150), rand.Next(1, 150)), new Point(rand.Next(0, 150), rand.Next(1, 150)) };
            return points;
        }
        /// <summary>
        /// Method for generating random text of 5 cahrecters as captcha code
        /// </summary>
        /// <returns></returns>
        private string GetRandomText(string page)
        {
            StringBuilder randomText = new StringBuilder();
            //string alphabets = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            string alphabets = "012345679";
            Random r = new Random();
            for (int j = 0; j <= 3; j++)
            {

                randomText.Append(alphabets[r.Next(alphabets.Length)]);
            }

            switch (page)
            {
                case "master":
                    break;
                case "register":
                    break;
                case "login":
                    Session[WebBase.SESSION_CAPTCHACODE_LOGIN] = randomText.ToString();
                    break;
            }
            return randomText.ToString();
        }
        #endregion

    }
}