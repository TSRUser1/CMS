using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SEM.Engine.BatchProcessParticipant.WCFCompetition;

namespace SEM.Engine.BatchProcessParticipant
{
    class Program
    {
        static void Main(string[] args)
        {
            CompetitionClient svc = new CompetitionClient();
            CompetitionDS requestDS = new CompetitionDS();
            CompetitionDS responseDS = new CompetitionDS();
            CompetitionDS.ParticipantDetailRow row = requestDS.ParticipantDetail.NewParticipantDetailRow();
            requestDS.ParticipantDetail.AddParticipantDetailRow(row);
            responseDS = svc.GetParticipantDetail(requestDS);

            if(responseDS != null)
            {
                foreach(CompetitionDS.ParticipantDetailRow participantRow in responseDS.ParticipantDetail)
                {
                    if (!participantRow.IsCardPhotoPathExternalNull())
                    {
                        string oldFileName = participantRow.CardPhotoPathExternal;
                        oldFileName = Directory.GetCurrentDirectory() + oldFileName;
                        string fileName = Path.GetFileName(oldFileName);
                        string filePath = Path.GetDirectoryName(oldFileName);
                        oldFileName = filePath + "/" + fileName.Trim();

                        System.IO.FileInfo oldFileInfo = new System.IO.FileInfo(oldFileName);

                        string newFile = participantRow.ParticipantID.ToString().PadLeft(6, '0') + ".jpg";
                        string newFileName = Directory.GetCurrentDirectory() + "/ParticipantImages/" + newFile;
                        System.IO.FileInfo newFileInfo = new System.IO.FileInfo(newFileName);

                        requestDS.Clear();
                        CompetitionDS.ParticipantDetailRow updateRow = requestDS.ParticipantDetail.NewParticipantDetailRow();
                        updateRow.ParticipantID = participantRow.ParticipantID;
                        updateRow.CardPhotoPath = "/ParticipantImages/" + newFile;
                        updateRow.CardPhotoPathThumbnail = "/ParticipantImages/" + participantRow.ParticipantID.ToString().PadLeft(6, '0') + "_tb.jpg";
                        updateRow.IsActive = 1;
                        updateRow.ModifiedBy = 9781;
                        requestDS.ParticipantDetail.AddParticipantDetailRow(updateRow);

                        // check if exists
                        if (oldFileInfo.Exists)
                        {
                            if (!newFileInfo.Exists) //only copy if newFilePath is not available
                            {
                                System.IO.File.Copy(oldFileName, newFileName);
                            }
                        }
                        svc.UpdateParticipantDetail(requestDS); //update after move, in case update fail can still recover.
                        Console.WriteLine(String.Format("ParticipantID: {0} processed.", participantRow.ParticipantID));
                        Console.WriteLine(String.Format("FilePath: {0}.", newFileName));
                    }
                }
            }
        }
    }
}
