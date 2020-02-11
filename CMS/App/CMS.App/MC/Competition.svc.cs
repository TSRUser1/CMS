using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SEM.CMS.CL.AR.Common;
using SEM.CMS.CL.MC.BF.CompetitionFacade;
using SEM.CMS.CL.MC.DS.CompetitionDataSet;
using System.IO;

namespace SEM.CMS.App.MC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Competition" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Competition.svc or Competition.svc.cs at the Solution Explorer and start debugging.
    public class Competition : ICompetition
    {
        public CompetitionDS InsertScheduleDetail(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertScheduleDetail(inputDS);
        }

        public CompetitionDS UpdateScheduleDetail(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateScheduleDetail(inputDS);
        }

        public CompetitionDS GetSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetSchedule(inputDS);
        }

        public CompetitionDS GetXMLSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetXMLSchedule(inputDS);
        }

        public CompetitionDS GetXMLMedalStanding(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetXMLMedalStanding(inputDS);
        }

        public CompetitionDS GetXMLLatestMedalist(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetXMLLatestMedalist(inputDS);
        }

        public CompetitionDS DeleteSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteSchedule(inputDS);
        }

        public CompetitionDS GetEventList(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetEventList(inputDS);
        }

        public CompetitionDS UpdateEvent(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateEvent(inputDS);
        }

        public CompetitionDS DeleteEvent(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteEvent(inputDS);
        }

        public CompetitionDS InsertEvent(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertEvent(inputDS);
        }

        public CompetitionDS GetEventDetails(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetEventDetails(inputDS);
        }

        public CompetitionDS InsertParticipantDetail(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertParticipantDetail(inputDS);
        }

        public CompetitionDS UpdateParticipantDetail(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateParticipantDetail(inputDS);
        }

        public CompetitionDS DeleteParticipant(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteParticipant(inputDS);
        }

        public CompetitionDS GetGeneralSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetGeneralSchedule(inputDS);
        }

        public CompetitionDS GetStartListParticipantList(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetStartListParticipantList(inputDS);
        }

        public CompetitionDS InsertStartList(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertStartList(inputDS);
        }

        public CompetitionDS GetStartListMaintenance(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetStartListMaintenance(inputDS);
        }

        public CompetitionDS UpdateStartList(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateStartList(inputDS);
        }

        public CompetitionDS UpdateStartListAssignTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateStartListAssignTeam(inputDS);
        }

        public CompetitionDS UpdateStartListPosition(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateStartListPosition(inputDS);
        }

        public CompetitionDS UpdateStartListByScheduleIDAndParticipantID(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateStartListByScheduleIDAndParticipantID(inputDS);
        }

        public CompetitionDS DeleteStartListParticipant(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteStartListParticipant(inputDS);
        }

        public CompetitionDS DeleteStartListByScheduleIDAndParticipantID(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteStartListByScheduleIDAndParticipantID(inputDS);
        }

        public CompetitionDS GetScheduleHeaderGroupedBySportFilteredByDate(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetScheduleHeaderGroupedBySportFilteredByDate(inputDS);
        }

        public CompetitionDS GetScheduleHeaderGroupedByDateFilteredBySport(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetScheduleHeaderGroupedByDateFilteredBySport(inputDS);
        }

        public CompetitionDS GetScheduleHeaderGroupedByDateFilteredByCountry(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetScheduleHeaderGroupedByDateFilteredByCountry(inputDS);
        }

        public CompetitionDS GetScheduleList(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetScheduleList(inputDS);
        }

        public CompetitionDS GetCountry(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetCountry(inputDS);
        }

        public CompetitionDS GetSport(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetSport(inputDS);
        }

        public CompetitionDS GetSportClass(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetSportClass(inputDS);
        }

        public CompetitionDS GetParticipantList(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantList(inputDS);
        }

        public CompetitionDS GetParticipantDetail(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantDetail(inputDS);
        }

        public CompetitionDS GetParticipantInTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantInTeam(inputDS);
        }

        public CompetitionDS GetParticipantInEventForTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantInEventForTeam(inputDS);
        }

        public CompetitionDS GetParticipantResult(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantResult(inputDS);
        }

        public CompetitionDS GetPartcipantAndScore(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetPartcipantAndScore(inputDS);
        }

        public CompetitionDS GetTeamAndScore(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetTeamAndScore(inputDS);
        }

        public CompetitionDS UpdateScore(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateScore(inputDS);
        }

        public CompetitionDS DeleteScore(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteScore(inputDS);
        }

        public CompetitionDS DeleteScoreByScheduleIDAndTeamID(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteScoreByScheduleIDAndTeamID(inputDS);
        }

        public CompetitionDS GetScoreName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetScoreName(inputDS);
        }

        public CompetitionDS UpdateScoreName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateScoreName(inputDS);
        }

        public CompetitionDS InsertScoreName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertScoreName(inputDS);
        }

        public CompetitionDS DeleteScoreName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteScoreName(inputDS);
        }

        public CompetitionDS InsertFile(CompetitionDS inputDS, byte[] source)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertFile(inputDS, source);
        }

        public CompetitionDS GetFileInEvent(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetFileInEvent(inputDS);
        }

        public CompetitionDS DeleteFileInEvent(CompetitionDS inputDS, string path, string fileName)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteFileInEvent(inputDS, path, fileName);
        }

        public byte[] DownloadFile(string path)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DownloadFile(path);
        }

        public CompetitionDS GetFinalRankings(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetFinalRankings(inputDS);
        }

        public CompetitionDS GetEventAthletes(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetEventAthletes(inputDS);
        }

        public CompetitionDS GetScheduleListForBanner(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetScheduleListForBanner(inputDS);
        }

        public CompetitionDS GetSportDetails(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetSportDetails(inputDS);
        }

        public CompetitionDS GetLatestMedalist(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetLatestMedalist(inputDS);
        }

        public CompetitionDS GetMedalStandings(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetMedalStandings(inputDS);
        }

        public CompetitionDS GetMedalStandingsByCountry(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetMedalStandingsByCountry(inputDS);
        }

        public CompetitionDS GetSportEventSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetSportEventSchedule(inputDS);
        }

        public CompetitionDS InsertScoreForParticipantInSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertScoreForParticipantInSchedule(inputDS);
        }

        public CompetitionDS InsertScoreForTeamInSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertScoreForTeamInSchedule(inputDS);
        }

        public CompetitionDS GetPartcipantAndStatistic(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetPartcipantAndStatistic(inputDS);
        }

        public CompetitionDS InsertStatisticForParticipantInSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertStatisticForParticipantInSchedule(inputDS);
        }

        public CompetitionDS UpdateStatistic(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateStatistic(inputDS);
        }

        public CompetitionDS GetStatisticName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetStatisticName(inputDS);
        }

        public CompetitionDS InsertStatisticName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertStatisticName(inputDS);
        }

        public CompetitionDS UpdateStatisticName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateStatisticName(inputDS);
        }

        public CompetitionDS UpdateScheduleExtraDetail(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateScheduleExtraDetail(inputDS);
        }

        public CompetitionDS GetReferee(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetReferee(inputDS);
        }

        public CompetitionDS UpdateReferee(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateReferee(inputDS);
        }

        public CompetitionDS InsertReferee(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertReferee(inputDS);
        }

        public CompetitionDS GetParticipantBiography(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantBiography(inputDS);
        }

        public CompetitionDS GetTeamBiography(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetTeamBiography(inputDS);
        }

        public CompetitionDS GetParticipantInEvent(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantInEvent(inputDS);
        }

        public CompetitionDS GetMedallist(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetMedallist(inputDS);
        }

        public CompetitionDS GetMultiMedallist(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetMultiMedallist(inputDS);
        }

        public CompetitionDS GetKnockoutSummary(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetKnockoutSummary(inputDS);
        }

        public CompetitionDS GetKnockoutSummaryForTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetKnockoutSummaryForTeam(inputDS);
        }

        public CompetitionDS GetLeagueSummary(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetLeagueSummary(inputDS);
        }

        public CompetitionDS GetLeagueSummaryForTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetLeagueSummaryForTeam(inputDS);
        }

        public CompetitionDS GetBrokenRecord(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetBrokenRecord(inputDS);
        }

        public CompetitionDS UpdateLeague(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateLeague(inputDS);
        }

        public CompetitionDS GetLeagueForIndividual(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetLeagueForIndividual(inputDS);
        }

        public CompetitionDS GetLeagueForTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetLeagueForTeam(inputDS);
        }

        public CompetitionDS InsertLeagueForTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertLeagueForTeam(inputDS);
        }

        public CompetitionDS InsertLeagueForIndividual(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertLeagueForIndividual(inputDS);
        }

        public CompetitionDS GetTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetTeam(inputDS);
        }

        public CompetitionDS UpdateTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateTeam(inputDS);
        }

        public CompetitionDS DeleteTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.DeleteTeam(inputDS);
        }

        public CompetitionDS InsertTeam(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertTeam(inputDS);
        }

        public CompetitionDS GetParticipantEvent(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetParticipantEvent(inputDS);
        }

        public CompetitionDS GetTeamEvent(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetTeamEvent(inputDS);
        }

        public CompetitionDS InsertStartListName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.InsertStartListName(inputDS);
        }

        public CompetitionDS UpdateStartListName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.UpdateStartListName(inputDS);
        }

        public CompetitionDS GetStartListName(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetStartListName(inputDS);
        }

        public CompetitionDS GetInitialRecord(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetInitialRecord(inputDS);
        }

        public CompetitionDS GetLiveSchedule(CompetitionDS inputDS)
        {
            AppBase.WCFAuthentication();
            CompetitionBF bf = new CompetitionBF();
            return bf.GetLiveSchedule(inputDS);
        }
    }
}
