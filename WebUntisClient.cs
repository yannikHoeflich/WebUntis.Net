using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WebUntis.Net {
    public class WebUntisClient {
        private readonly string School;
        private readonly string Username;
        private readonly string Password;
        private readonly string BaseUrl;
        private readonly string Id;
        private readonly bool Anonymous;
        private readonly HttpClient client;

        /// <summary>
        /// Console print some informations for example all responses
        /// </summary>
        public bool Debug = false;


        private SessionInformation SessionInformation;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="school">school name [url]/schoolname</param>
        /// <param name="username">your webuntis username</param>
        /// <param name="password">yout webuntis password</param>
        /// <param name="schoolUrl">schoolshort.webuntis.com</param>
        /// <param name="id">something, is not needed in most cases</param>
        public WebUntisClient( string school , string username , string password , string schoolUrl , string id = "WebUntisDotNet" ) {
            School = school;
            Username = username;
            Password = password;
            BaseUrl = "https://" + schoolUrl + "/";
            Id = id;
            Anonymous = false;


            client = new HttpClient( );
            client.DefaultRequestHeaders.Add( "User-Agent" , "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.79 Safari/537.36" );
            client.DefaultRequestHeaders.Add( "Cache-Control" , "no-cache" );
            client.DefaultRequestHeaders.Add( "Pragma" , "no-cache" );
            client.DefaultRequestHeaders.Add( "X-Requested-With" , "XMLHttpRequest" );

            client.BaseAddress = new Uri( BaseUrl );
        }

        #region public methods
        /// <summary>
        /// logout
        /// </summary>
        /// <returns>nothing</returns>
        public async Task LogoutAsync( ) {
            _request<object>( "logout" , new Dictionary<string , object>( ) );
        }

        /// <summary>
        /// login
        /// </summary>
        /// <returns>nothing</returns>
        public async Task Login( ) {
            RequestPostData data = new RequestPostData(){
                id = this.Id,
                method = "authenticate",
                jsonrpc = "2.0"
            };

            data.@params.Add( "user" , this.Username );
            data.@params.Add( "password" , Password );
            data.@params.Add( "client" , this.Id );

            HttpContent content = new StringContent( JsonConvert.SerializeObject(data) , Encoding.UTF8 , "application/json" );
            HttpResponseMessage response = await client.PostAsync( "WebUntis/jsonrpc.do?school=" + School , content );

            response.EnsureSuccessStatusCode( );

            string str = await response.Content.ReadAsStringAsync( );
            if( Debug )
                Console.WriteLine( str );

            SessionInformation = JsonConvert.DeserializeObject<SessionInformationTemporary>( str ).result;
        }

        /// <summary>
        /// get your own Timetable for today
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns></returns>
        public async Task<TimeTable> GetOwnTimetableForToday( bool validateSession = true ) {
            _checkAnonymous( );
            return await _timetableRequest( SessionInformation.PersonId , SessionInformation.PersonType , DateTime.Now , DateTime.Now , validateSession );
        }

        /// <summary>
        /// Get Timetable of other person of today
        /// </summary>
        /// <param name="id">person id</param>
        /// <param name="type">person type</param>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>the Timatable</returns>
        public async Task<TimeTable> GetTimetableForToday( int id , int type , bool validateSession = true ) {
            return await this._timetableRequest( id , type , DateTime.Now , DateTime.Now , validateSession );
        }

        /// <summary>
        /// Get yout timetable for another name
        /// </summary>
        /// <param name="date">the date wich you want to have the timetable</param>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>the Timetable</returns>
        public async Task<TimeTable> GetOwnTimetableFor( DateTime date , bool validateSession = true ) {
            this._checkAnonymous( );
            return await this._timetableRequest( SessionInformation.PersonId , SessionInformation.PersonType , date , date , validateSession );
        }

        /// <summary>
        /// Get a timetable of another person on another day
        /// </summary>
        /// <param name="date">the date which you want to have the timetable</param>
        /// <param name="id">ther persons id</param>
        /// <param name="type">the person type</param>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>the Timetable</returns>
        public async Task<TimeTable> GetTimetableFor( DateTime date , int id , int type , bool validateSession = true ) {
            return await this._timetableRequest( id , type , date , date , validateSession );
        }

        /// <summary>
        /// Get Own TimeTable for a range of days
        /// </summary>
        /// <param name="rangeStart">Date of the first timetable</param>
        /// <param name="rangeEnd">Date of the last timetable</param>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an timetable that contains all subjects in the range of dates</returns>
        public async Task<TimeTable> GetOwnTimetableForRange( DateTime rangeStart , DateTime rangeEnd , bool validateSession = true ) {
            this._checkAnonymous( );
            return await this._timetableRequest( SessionInformation.PersonId , SessionInformation.PersonType , rangeStart , rangeEnd , validateSession );
        }

        /// <summary>
        /// Gets the timetable in a range of dates for another student
        /// </summary>
        /// <param name="rangeStart">Date of the first timetable</param>
        /// <param name="rangeEnd">Date of the last timetable</param>
        /// <param name="id">ther persons id</param>
        /// <param name="type">the person type</param>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an timetable that contains all subjects in the range of dates</returns>
        public async Task<TimeTable> GetTimetableForRange( DateTime rangeStart , DateTime rangeEnd , int id , int type , bool validateSession = true ) {
            return await this._timetableRequest( id , type , rangeStart , rangeEnd , validateSession );
        }

        /// <summary>
        /// gets the timetable of the own class for totay
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>the timetable</returns>
        public async Task<TimeTable> getOwnClassTimetableForToday( bool validateSession = true ) {
            this._checkAnonymous( );
            return await this._timetableRequest( SessionInformation.KlasseId , 1 , DateTime.Now , DateTime.Now , validateSession );
        }

        /// <summary>
        /// gets the timetable of the own class for another day
        /// </summary>
        /// <param name="date">the date wich you want to have the timetable</param>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>the timetable</returns>
        public async Task<TimeTable> getOwnClassTimetableFor( DateTime date , bool validateSession = true ) {
            this._checkAnonymous( );
            return await this._timetableRequest( SessionInformation.KlasseId , 1 , date , date , validateSession );
        }

        /// <summary>
        /// gets the timetable of the own class for a range of days
        /// </summary>
        /// <param name="rangeStart">Date of the first timetable</param>
        /// <param name="rangeEnd">Date of the last timetable</param>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns></returns>
        public async Task<TimeTable> getOwnClassTimetableForRange( DateTime rangeStart , DateTime rangeEnd , bool validateSession = true ) {
            this._checkAnonymous( );
            return await this._timetableRequest( SessionInformation.KlasseId , 1 , rangeStart , rangeEnd , validateSession );
        }

        /// <summary>
        /// gets the homeworks for a range of days
        /// </summary>
        /// <param name="rangeStart">the start for the days</param>
        /// <param name="rangeEnd">the end date of the range of days</param>
        /// <returns></returns>
        public async Task<List<HomeWork>> GetHomeWorksFor( DateTime rangeStart , DateTime rangeEnd ) {
            string url = "/WebUntis/api/homeworks/lessons?startDate=" + ConvertDateToUntis(rangeStart) + "&endDate=" + ConvertDateToUntis(rangeEnd);
            var response = await client.GetAsync( url );
            string str = await response.Content.ReadAsStringAsync( );
            var list = JsonConvert.DeserializeObject<HomeWorkResponse>( str ).Data.Homeworks;
            list.ForEach( x => x.Parse( ) );
            return list;
        }


        /// <summary>
        /// get all rooms of the school
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an array of rooms</returns>
        public async Task<List<Room>> GetRooms( bool validateSession = true ) {
            return (await _request<List<Room>>( "getRooms" , new Dictionary<string , object>( ) , validateSession )).result;
        }

        /// <summary>
        /// get all classes of the school
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an array of classes</returns>
        public async Task<List<UntisClass>> GetClasses( bool validateSession = true ) {
            return (await _request<List<UntisClass>>( "getKlassen" , new Dictionary<string , object>( ) , validateSession )).result;
        }

        /// <summary>
        /// gets all holidays that are registered
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an array of holidays</returns>
        public async Task<List<Holidays>> GetHolidays( bool validateSession = true ) {
            List<Holidays> holidayList = (await _request<List<Holidays> >( "getHolidays" , new Dictionary<string , object>( ) , validateSession )).result;
            holidayList.ForEach( x => x.Convert( ) );
            return holidayList;
        }

        /// <summary>
        /// gets all teacher of the school
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an array of teachers</returns>
        public async Task<List<Teacher>> GetTeachers( bool validateSession = true ) {
            return (await _request<List<Teacher>>( "getTeachers" , new Dictionary<string , object>( ) , validateSession )).result;
        }

        /// <summary>
        /// gets all students of the school
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an array of students</returns>
        public async Task<List<Student>> GetStudents( bool validateSession = true ) {
            return (await _request<List<Student>>( "getStudents" , new Dictionary<string , object>( ) , validateSession )).result;
        }

        /// <summary>
        /// gets all subjects that are teached on that school
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an array of subjects</returns>
        public async Task<List<Subject>> GetSubjects( bool validateSession = true ) {
            return (await _request<List<Subject>>( "getSubjects" , new Dictionary<string , object>( ) , validateSession )).result;
        }

        /// <summary>
        /// gets your timegrid of a week of your school
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>an array of timegrid days</returns>
        public async Task<List<TimeGridDay>> GetTimegrid( bool validateSession = true ) {
            List<TimeGridDay> days = (await _request<List<TimeGridDay>>( "getTimegridUnits" , new Dictionary<string , object>( ) , validateSession )).result;
            foreach( var day in days ) {
                foreach( var unit in day.TimeUnits ) {
                    unit.Parse( );
                }
            }
            return days;
        }

        /// <summary>
        /// gets the current school year(id etc.)
        /// </summary>
        /// <param name="validateSession">checks if session stays valid</param>
        /// <returns>the school year object</returns>
        public async Task<SchoolYear> GetCurrentSchoolyear( bool validateSession = true ) {
            return (await _request<SchoolYear>( "getCurrentSchoolyear" , new Dictionary<string , object>( ) , validateSession )).result;
        }
        #endregion

        #region private methods
        private void _checkAnonymous( ) {
            if( Anonymous )
                throw new AnonymousLoginException( );
        }

        private async Task<TimeTable> _timetableRequest( int personId , int personType , DateTime StartDate , DateTime EndDate , bool validateSession = true ) {
            OptionRequestData options = new OptionRequestData();
            options.id = DateTimeOffset.UtcNow.ToUnixTimeSeconds( );
            options.additionalOptions = new DateAdditionalOptions( StartDate , EndDate );
            options.element = new User( ) {
                id = personId ,
                type = personType
            };
            options.showLsText = true;
            options.showStudentgroup = true;
            options.showLsNumber = true;
            options.showSubstText = true;
            options.showInfo = true;
            options.showBooking = true;

            options.klasseFields = new string[] { "id" , "name" , "longname" , "externalkey" };
            options.roomFields = new string[] { "id" , "name" , "longname" , "externalkey" };
            options.subjectFields = new string[] { "id" , "name" , "longname" , "externalkey" };
            options.teacherFields = new string[] { "id" , "name" , "longname" , "externalkey" };

            return (await _request<TimeTable>( "getTimetable" , new Dictionary<string , object>( ) { { "options" , options } } , validateSession )).result;
        }


        private async Task<Answer<T>> _request<T>( string method , Dictionary<string , object> parameters , bool validateSession = true , string url = null ) {
            if( validateSession ) {
                if( !(await _validateSeassion( )) ) {
                    throw new InvalidOperationException( "Current Session is not valid" );
                }
            }
            if( url == null )
                url = "WebUntis/jsonrpc.do?school=" + School;
            RequestPostData data = new RequestPostData(){
                id = this.Id,
                method = method,
                jsonrpc = "2.0"
            };

            data.@params = parameters;

            HttpContent content = new StringContent( JsonConvert.SerializeObject(data) , Encoding.UTF8 , "application/json" );
            HttpResponseMessage response = await client.PostAsync( url , content );

            response.EnsureSuccessStatusCode( );

            if( Debug )
                Console.WriteLine( await response.Content.ReadAsStringAsync( ) );

            return JsonConvert.DeserializeObject<Answer<T>>( await response.Content.ReadAsStringAsync( ) );
        }


        private async Task<bool> _validateSeassion( ) {
            return long.TryParse( (await _request<object>( "getLatestImportTime" , new Dictionary<string , object>( ) , false )).result.ToString( ) , out long t );
        }
        #endregion

        #region static methods
        public static string ConvertDateToUntis( DateTime date ) {
            return
                (date.Year.ToString( ) +
                (date.Month < 10 ? "0" + date.Month.ToString( ) : date.Month.ToString( )) +
                (date.Day < 10 ? "0" + date.Day.ToString( ) : date.Day.ToString( ))
            );
        }
        public static DateTime ConvertUntisToDate( int UntisDate ) {
            string str = UntisDate.ToString();
            string year = str.Substring(0, 4);
            string month = str.Substring(4, 2);
            string day = str.Substring(6, 2);

            return DateTime.Parse( day + "." + month + "." + year , CultureInfo.CreateSpecificCulture( "de-DE" ) );
        }


        public static string ConvertTimeToUntis( DateTime date ) {
            return (
                date.Hour.ToString( ) +
                (date.Minute < 10 ? "0" + date.Minute.ToString( ) : date.Minute.ToString( ))
            );
        }
        public static DateTime ConvertUntisToTime( int UntisDate ) {
            string str = UntisDate.ToString();
            string hour;
            string minute;

            if( str.Length == 3 ) {
                hour = str.Substring( 0 , 1 );
                minute = str.Substring( 1 , 2 );
            } else {
                hour = str.Substring( 0 , 2 );
                minute = str.Substring( 2 , 2 );
            }

            return DateTime.Parse( "1.1.2000 " + hour + ":" + minute , CultureInfo.CreateSpecificCulture( "de-DE" ) );
        }
        #endregion
    }
}
