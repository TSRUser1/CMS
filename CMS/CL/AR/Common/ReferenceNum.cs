using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEM.CMS.CL.AR.Common
{
    public class ReferenceNum
    {
        #region ReferenceCategory
        public enum ReferenceCategory : int
        {
            DataColumnType = 1,
            Gender = 2,
            CompetitionFormatType = 3,
            EventType = 4,
            StatusCode = 5,
            MedalType = 6,
            ResultPosition = 7,
            FileGroupType = 8,
            ParticipantType = 9
        }
        #endregion

        #region 1 DataColumnType
        public enum DataColumnType : int
        {
            Text = 1,
            Hyperlink = 2,
            CheckBox = 3,
            TextBox = 4,
            DropDown = 5
        }
        #endregion

        #region 2 Gender
        public enum Gender : int
        {
            Men = 1,
            Women = 2,
            Mixed = 3
        }
        #endregion

        #region 3 CompetitionFormatType
        public enum CompetitionFormatType : int
        {
            KnockOut = 1,
            League = 2,
            Time_Distance_Points = 3
        }
        #endregion

        #region 4 EventType
        public enum EventType : int
        {
            Individual = 1,
            Doubles = 2,
            Team = 3
        }
        #endregion

        #region 5 StatusCode
        public enum StatusCode : int
        {
            PL = 1,
            SR = 2,
            RN = 3,
            PP = 4,
            DL = 5,
            RS = 6,
            CN = 7,
            CP = 8,
            OF = 9
        }
        #endregion

        #region 6 MedalType
        public enum MedalType : int
        {
            None = 0,
            Gold = 1,
            Silver = 2,
            Bronze = 3
        }
        #endregion

        #region 7 ResultPosition
        public enum ResultPosition
        {
            None = 0,
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Fifth = 5,
            Sixth = 6,
            Seventh = 7,
            Eighth = 8,
            Ninth = 9,
            Tenth = 10,
            Eleventh = 11,
            Twelfth = 12,
            Thirteenth = 13,
            Fourteenth = 14,
            Fifteenth = 15,
            Sixteenth = 16,
            Seventeenth = 17,
            Eighteenth = 18,
            Nineteenth = 19,
            Twentieth = 20,
            E001 = 101 ,
            E002 = 102,
            E003 = 103,
            E004 = 104,
            E005 = 105
        }
        #endregion

        #region 8 FileGroupType
        public enum FileGroupType : int
        {
            Entry = 4,
            Schedule = 2,
            Startlist = 1,
            Result = 3,
            Medal = 5,
            Summary = 6,
            OffcialCommunication = 7
        }

        #endregion

        #region 9 ParticipantType
        public enum ParticipantType : int
        {
            Starting = 1,
            Substitute = 2,
            TeamOfficial = 3
        }

        #endregion

        #region 10 MainCategory
        public enum MainCategory : int
        {
            Athletes = 19,
            SportAssist = 20,
            TeamManager = 21,
            Coach = 27,
            AddTeamOff = 31
        }

        #endregion

        public enum Sport
        {
            [EnumMember(Value = "BADMINTON")]
            BADMINTON = 1,
            [EnumMember(Value = "FOOTBALL 5-A-SIDE")]
            FOOTBALL5 = 2,
            [EnumMember(Value = "ARCHERY")]
            ARCHERY = 4,
            [EnumMember(Value = "ATHLETICS")]
            ATHLETICS = 5,
            [EnumMember(Value = "BOCCIA")]
            BOCCIA = 6,
            [EnumMember(Value = "CHESS")]
            CHESS = 7,
            [EnumMember(Value = "CEREBRAL PALSY FOOTBALL")]
            CPFOOTBALL = 8,
            [EnumMember(Value = "GOALBALL")]
            GOALBALL = 9,
            [EnumMember(Value = "POWERLIFTING")]
            POWERLIFTING = 10,
            [EnumMember(Value = "SAILING")]
            SAILING = 11,
            [EnumMember(Value = "SHOOTING")]
            SHOOTING = 12,
            [EnumMember(Value = "SWIMMING")]
            SWIMMING = 13,
            [EnumMember(Value = "TABLE TENNIS")]
            TABLETENNIS = 14,
            [EnumMember(Value = "TENPIN BOWLING")]
            TENPINBOWLING = 15,
            [EnumMember(Value = "WHEELCHAIR BASKETBALL")]
            WHEELCHAIRBASKETBALL = 16
        }

        public enum Country
        {
            [EnumMember(Value = "Brunei Darussalam")] 
            BruneiDarussalam = 1 ,
            [EnumMember(Value = "Cambodia")] 
            Cambodia = 4 ,
            [EnumMember(Value = "Democratic Republic of Timor-Leste")] 
            DemocraticRepublicofTimorLeste = 5 ,
            [EnumMember(Value = "Indonesia")] 
            Indonesia = 6 ,
            [EnumMember(Value = "Lao People's Democratic Republic")] 
            LaoPeoplesDemocraticRepublic = 7 ,
            [EnumMember(Value = "Malaysia")] 
            Malaysia = 8 ,
            [EnumMember(Value = "Myanmar")] 
            Myanmar = 9 ,
            [EnumMember(Value = "Philipines")] 
            Philipines = 10 ,
            [EnumMember(Value = "Singapore")] 
            Singapore = 12 ,
            [EnumMember(Value = "Thailand")] 
            Thailand = 13 ,
            [EnumMember(Value = "Vietnam")] 
            Vietnam = 14 
        }

        public static string ToEnumString<T>(T type)
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }

        public static T ToEnum<T>(string str)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            }
            //throw exception or whatever handling you want or
            return default(T);
        }

        public void function()
        {
            Sport e = (Sport)Enum.ToObject(typeof(Sport), 8);
            string name = ToEnumString<Sport>(Sport.CPFOOTBALL); //returns "CEREBRAL PALSY FOOTBALL"
            name = ToEnumString<Sport>(e); //returns "CEREBRAL PALSY FOOTBALL"
            var t = ToEnum<Sport>("CEREBRAL PALSY FOOTBALL");
            int eNum = Convert.ToInt32(t); //returns 8
        }

    }
}
