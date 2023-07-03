# Untis.NET
Untis.NET is an unofficial API Wrapper for WebUntis, which is used by many schools. It shows the timetable, missing hours, homeworks, etc.
With Untis.NET you can login into your profile and create own applications with the data.

## Getting Started

### Install
You can either install the [nuget](https://www.nuget.org/packages/WebUntis.Net/) package via the Nuget manager in Visual Studio 
**or**
use the Package Manager

```
NuGet\Install-Package WebUntis.Net
```

### Create Client
Next you create a client
```cs
var client = UntisClient("school name", "school url");
```
To get both values (school name and school url) you have 
1. go on [WebUntis](https://webuntis.com/).
2. search for your school
3. The domain is the school url (for example `nessa.webuntis.com`)
4. In the query of the url is ?school=`school name`

### Login
You login with `LoginAsync`:
```c#
await client.LoginAsync("your username", "your password");
```

### Use
The client is now ready to use. To get your homeworks just do
```cs
var UntisHomeWork[] homeworks = await client.GetHomeworksAsync();
```

## Documentation
We have our documentation in the [wiki](/wiki)

## Bugs or Feature requests?
You can just create an Issue in this repository.

## Contribution
Normal stuff, either create an Issue or fork this project and later make a pull request to get your code into the project.