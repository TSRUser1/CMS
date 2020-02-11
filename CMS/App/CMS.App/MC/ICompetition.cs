using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SEM.CMS.CL.MC.DS.CompetitionDataSet;
using System.IO;

namespace SEM.CMS.App.MC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompetition" in both code and config file together.
    [ServiceContract]
    public interface ICompetition
    {
        [OperationContract]
        CompetitionDS InsertScheduleDetail(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateScheduleDetail(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetXMLSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetXMLMedalStanding(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetXMLLatestMedalist(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetEventList(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateEvent(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteEvent(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertEvent(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetEventDetails(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertParticipantDetail(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateParticipantDetail(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteParticipant(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetGeneralSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetStartListParticipantList(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertStartList(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetStartListMaintenance(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateStartList(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateStartListAssignTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateStartListPosition(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateStartListByScheduleIDAndParticipantID(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteStartListParticipant(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteStartListByScheduleIDAndParticipantID(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetScheduleHeaderGroupedBySportFilteredByDate(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetScheduleHeaderGroupedByDateFilteredBySport(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetScheduleHeaderGroupedByDateFilteredByCountry(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetScheduleList(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetLiveSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetCountry(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetSport(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetSportClass(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantList(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantDetail(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantInTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantInEventForTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantResult(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetPartcipantAndScore(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetTeamAndScore(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateScore(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertScoreForParticipantInSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertScoreForTeamInSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteScore(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteScoreByScheduleIDAndTeamID(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetScoreName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateScoreName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertScoreName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteScoreName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetPartcipantAndStatistic(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertStatisticForParticipantInSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateStatistic(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetStatisticName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertStatisticName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateStatisticName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertFile(CompetitionDS inputDS, byte[] source);

        [OperationContract]
        CompetitionDS GetFileInEvent(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteFileInEvent(CompetitionDS inputDS, string path, string fileName);

        [OperationContract]
        byte[] DownloadFile(string path);

        [OperationContract]
        CompetitionDS GetFinalRankings(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetEventAthletes(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetScheduleListForBanner(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetSportDetails(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetLatestMedalist(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetMedalStandings(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetMedalStandingsByCountry(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetSportEventSchedule(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateScheduleExtraDetail(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetReferee(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateReferee(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertReferee(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantBiography(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetTeamBiography(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantInEvent(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetMedallist(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetMultiMedallist(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetKnockoutSummary(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetKnockoutSummaryForTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetLeagueSummary(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetLeagueSummaryForTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetBrokenRecord(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetLeagueForIndividual(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetLeagueForTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertLeagueForTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertLeagueForIndividual(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateLeague(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS DeleteTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertTeam(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetParticipantEvent(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetTeamEvent(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS InsertStartListName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS UpdateStartListName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetStartListName(CompetitionDS inputDS);

        [OperationContract]
        CompetitionDS GetInitialRecord(CompetitionDS inputDS);
    }
}
