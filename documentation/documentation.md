# Getting Started
### login and get todays timetable
```cs
WebUntisClient client = new WebUntisClient("school name(from url)", "username", "password", "raw url (letters.webuntis.com)");

await client.LoginAsync();

TimeTable tt = await client.getOwnClassTimetableForDateAsync(DateTime.Now);
```

### login and get homeworks for the next 7 days
```cs
WebUntisClient client = new WebUntisClient("school name(from url)", "username", "password", "raw url (letters.webuntis.com)");

await client.LoginAsync();

var HomeWorks = await client.GetHomeWorksForDateAsync( DateTime.Now , DateTime.Now + TimeSpan.FromDays(7) );
```

### get all new homeworks and update every hour
```cs
readonly List<int> Existing = new List<int>();

WebUntisClient client = new WebUntisClient("school name(from url)", "username", "password", "raw url (letters.webuntis.com)");

await client.LoginAsync();
client.StartKeepAlive( );

while( true ) {
    List<HomeWork> homeworks = await UntisClient.GetHomeWorksForDateAsync( DateTime.Now , DateTime.Now + TimeSpan.FromDays( 30 ) 
    foreach( HomeWork hw in homeworks ) {
        if( !Existing.Contains( hw.Id ) ) {
            Existing.Add( hw.Id );

            //code for new homeworks
        }
    }
    Thread.Sleep(TimeSpan.FromHours(1));
}

```

# non static Methods

## LoginAsync
To login the client

**takes**
- nothing

**returns**
- nothing

**example**
```cs 
await client.LoginAsync();
```

## LogoutAsync
To logout the client

**takes**
- nothing

**returns**
- nothing

**example**
```cs 
await client.LogoutAsync();
```

## StartKeepAlive
Start a **new Thread** which makes a request every minute to keep the session alive

**takes**
- nothing

**returns**
- nothing

**example**
```cs 
client.StartKeepAlive( );
```

## GetOwnTimetableForDateAsync
Gets own timetable for a day

**takes**
- DateTime date: the date of the timetable
- bool validateSession *default: true*

**returns**
- [TimeTable](#timetable--icollectiontimetablepart-icloneable)

**example**
```cs 
TimeTable timetable = await client.GetOwnTimetableForDateAsync(DateTime.Now);
```

## GetTimetableForDateAsync
Gets the timetable of another person for a day

**takes**
- DateTime date: the date of the timetable
- int id: persons id
- int type: persons type
- bool validateSession *default: true*

**returns**
- [TimeTable](#timetable--icollectiontimetablepart-icloneable)

**example**
```cs 
TimeTable timetable = await client.GetTimetableForDateAsync(DateTime.Now, 3542, 5);
```

## GetOwnTimetableForRangeAsync
Gets the own timetable for a range of days

**takes**
- DateTime rangeStart: the start of the day range
- DateTime rangeEnd: the end of the day range
- bool validateSession *default: true*

**returns**
- [TimeTable](#timetable--icollectiontimetablepart-icloneable)

**example**
```cs 
TimeTable timetable = await client.GetOwnTimetableForRangeAsync(DateTime.Now, DateTime + TimeSpan.FormDays(7));
```

## GetTimetableForRangeAsync
Gets the timetable of another person for a range of days

**takes**
- DateTime rangeStart: the date of the timetable
- DateTime rangeEnd: the date of the timetable
- int id: persons id
- int type: persons type
- bool validateSession *default: true*

**returns**
- [TimeTable](#timetable--icollectiontimetablepart-icloneable)

**example**
```cs 
TimeTable timetable = await client.GetOwnTimetableForRangeAsync(DateTime.Now, DateTime + TimeSpan.FormDays(7), 3542, 5);
```

## getOwnClassTimetableForDateAsync
Gets the timetable of the own class for a day

**takes**
- DateTime date: the date of the timetable
- bool validateSession *default: true*

**returns**
- [TimeTable](#timetable--icollectiontimetablepart-icloneable)

**example**
```cs 
TimeTable timetable = await client.getOwnClassTimetableForDateAsync(DateTime.Now);
```

## getOwnClassTimetableForRangeAsync
Gets the timetable of the own class for a range if days

**takes**
- DateTime rangeStart: the date of the timetable
- DateTime rangeEnd: the date of the timetable
- bool validateSession *default: true*

**returns**
- [TimeTable](#timetable--icollectiontimetablepart-icloneable)

**example**
```cs 
TimeTable timetable = await client.getOwnClassTimetableForRangeAsync(DateTime.Now, DateTime + TimeSpan.FormDays(7));
```

## GetHomeWorksForDateAsync
Gets an array of homeworks for a range of days

**takes**
- DateTime rangeStart: the date of the timetable
- DateTime rangeEnd: the date of the timetable

**returns**
- List<[HomeWork](#homework)>

**example**
```cs 
List<HomeWork> homeworks = await client.GetHomeWorksForDateAsync(DateTime.Now, DateTime + TimeSpan.FormDays(7));
```

## GetRoomsAsync
Gets an array of all rooms of the school

**takes**
- bool validateSession *default: true*

**returns**
- List<[Room](#room)>

**example**
```cs 
List<Room> rooms = await client.GetRoomsAsync();
```

## GetClassesAsync
Gets an array of all classes of the school

**takes**
- bool validateSession *default: true*

**returns**
- List<[UntisClass](#untisclass)>

**example**
```cs 
List<UntisClass> homeworks = await client.GetClassesAsync();
```

## GetHolidaysAsync
Gets an array of the next holidays

**takes**
- bool validateSession *default: true*

**returns**
- List<[Holidays](#holidays)>

**example**
```cs 
List<Holidays> holidays = await client.GetHolidaysAsync();
```

## GetTeachersAsync
Gets an array of all teachers of the school

**takes**
- bool validateSession *default: true*

**returns**
- List<[Teacher](#teacher)>

**example**
```cs 
List<Teacher> homeworks = await client.GetTeachersAsync();
```

## GetStudentsAsync
Gets an array of all students of the school

**takes**
- bool validateSession *default: true*

**returns**
- List<[Student](#student)>

**example**
```cs 
List<Student> students = await client.GetStudentsAsync();
```

## GetSubjectsAsync
Gets an array of all subjects of the school

**takes**
- bool validateSession *default: true*

**returns**
- List<[Subject](#subject)>

**example**
```cs 
List<Subject> subjects = await client.GetSubjectsAsync();
```

## GetTimegridAsync
Gets the timegrid of the timetable of the school

**takes**
- bool validateSession *default: true*

**returns**
- List<[TimeGridDay](#timegridday)>

**example**
```cs 
List<TimeGridDay> timegrid = await client.GetTimegridAsync();
```

## GetCurrentSchoolyearAsync
Gets the informations for the curent Schholyear

**takes**
- bool validateSession *default: true*

**returns**
- [SchoolYear](#schoolyear)

**example**
```cs 
SchoolYear schoolyear = await client.GetCurrentSchoolyearAsync();
```

# Properties
## SessionInformation {get; private set;}

**Type**
- [SessionInformation](#sessioninformation)

# static methods

## ConvertDateToUntis
Converts a date to untis date format

**takes**
- DateTime date: *time doesn't metter*

**returns**
- int

**example**
```cs 
int untisDate = ConvertDateToUntis(new DateTime(2020, 8, 31));
```

## ConvertUntisToDate
Converts a date as untis date format to a DateTime object

**takes**
- int UntisDate

**returns**
- DateTime

**example**
```cs 
DateTime date = ConvertUntisToDate(20200831);
```

## ConvertTimeToUntis
Converts a time to untis time format

**takes**
- DateTime time: *date doesn't metter*

**returns**
- int

**example**
```cs 
int untisTime = ConvertTimeToUntis(new DateTime(2020, 8, 31, 12, 0, 0));
```

## ConvertUntisToTime
Converts a time as untis time format to a DateTime object

**takes**
- int UntisTime: *date doesn't metter*

**returns**
- DateTime

**example**
```cs 
int untisDate = ConvertUntisToTime("1200");
```

# Types
## Holidays
**properties**
- int Id
- string Name
- string LongName
- int StartDateUntis
- int EndDateUntis
- DateTime StartDate
- DateTime EndDate
  
**methods**
- void Convert(): converts the Untis formats to DateTime


## HomeWork
**properties**
- int Id
- int LessonId
- int DateUntis
- int DueDateUntis
- string Text
- string Remark
- bool Completed
- string[] Attachments
- DateTime Date
- DateTime DueDate
- [LessonHomeWork](#lessonhomework) Subject
  
**methods**
- void Convert(): converts the Untis formats to DateTime *WebUntisClient calls it automaticly*


## LessonHomeWork
**properties**
- int Id
- string Subject
- string LessonType


**methods**
- [Subject](#subject) ParseToSubject( IEnumerable<Subject> subjects )
- bool TryParseToSubject( IEnumerable<Subject> subjects , out [Subject](#subject) subject ) 


## Room
**properties**
- int Id
- string Name
- string LongName
- bool Active
- string ForeColor
- string BackColor
- int Did
- string Building

**methods**
- none


## SchoolYear
**properties**
- int Id
- string Name
- string LongName
- int StartDateUntis
- int EndDateUntis
- DateTime StartDate
- DateTime EndDate

**methods**
- void Convert(): converts the Untis formats to DateTime *WebUntisClient calls it automaticly*


## SessionInformation
**properties**
- string SessionId
- int PersonId
- int PersonType
- int ClassId

**methods**
- none


## Student
**properties**
- int Id
- int Key
- string Name
- string Forename
- string LongName
- string Gender

**methods**
- none


## Subject
**properties**
- int Id
- string Name
- string LongName
- string ForeColor
- string BackColor

**methods**
- none


## Teacher
**properties**
- int Id
- string Name
- string Forename
- string LongName
- string ForeColor
- string BackColor

**methods**
- none


## TimeGridDay
**properties**
- int Day
- List<[TimeGridDayUnit](#timegriddayunit)> TimeUnits

**methods**
- none

**other**
- working indexer (TimeGridDay[i]) only get


## TimeGridDayUnit
**properties**
- string Name
- int StartDateUntis
- int EndDateUntis
- DateTime StartDate
- DateTime EndDate

**methods**
- void Convert(): converts the Untis formats to DateTime *WebUntisClient calls it automaticly*

## TimeTable : *ICollection<[TimeTablePart](#timetablepart--icloneable)>, ICloneable*
**properties**
- int Count
- bool IsReadOnly: *false*

**methods**
- void Add( TimeTablePart item )
- void Clear( )
- bool Contains( TimeTablePart item )
- void CopyTo( TimeTablePart[] array , int arrayIndex )
- bool Remove( TimeTablePart item )
- IEnumerator<[TimeTablePart](#timetablepart--icloneable)> GetEnumerator( )
- object Clone( )

**constructors**
- public TimeTable( List<[TimeTablePart](#timetablepart--icloneable)> parts )

**other**
- working indexer get(TimeTable[i])

## TimeTablePart : *ICloneable*
**properties**
- int Id
- int Date
- int StartTimeUntis
- int EndTimeUntis
- List<[UntisClass](#untisclass)> Classes
- List<[Subject](#subject)> Subjects
- List<[Room](#room)> Rooms
- int Lsnumber
- string ActivityType
- DateTime StartTime
- DateTime EndTime

**methods**
- object Clone()
- void Convert(): converts the Untis formats to DateTime *WebUntisClient calls it automaticly*


## UntisClass
**properties**
- int Id
- string Name
- string LongName
- bool Active
- int Did
- string ForeColor
- string BackColor
- int Teacher1
- int Teacher2
- int Teacher3


**methods**
- none


## UntisUser
**properties**
- int Id
- int Type


**methods**
- none


# Exceptions
## AnonymousLoginException
is thrown when you try to get "own" data but are login as Anonymous