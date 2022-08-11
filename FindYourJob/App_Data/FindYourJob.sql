
use FindYourJob



create table UserTypes (
UserTypeID int PRIMARY KEY IDENTITY (1, 1) ,
UserType varchar(150) ,

);


create table Users (

UserID int PRIMARY KEY IDENTITY (1, 1),
UserTypeID int ,
UserName varchar(150),
Password varchar(150),
EmailAddress varchar(150),
ContactNo varchar(14),
AccountStatusID int

);


create table AccountStatus (
AccountStatusID int PRIMARY KEY IDENTITY (1, 1),
AccountStatus varchar(150)

);


INSERT INTO AccountStatus
VALUES ('Review'),
('Approved'),
('Rejected'),
('Suspended');



create table Employee
(

EmployeeID int PRIMARY KEY IDENTITY (1, 1),
UserID int,
JobCategoryID int,
EmployeeName varchar(150),
DOB date,
NID varchar(25),
FatherName varchar(150),
CountryID int,
EmailAddress varchar(150),
Gender Varchar (100),
Photo varchar (MAX),
Qualification varchar(200),
PermanentAddres varchar (400),
JobReferences varchar (250),
Description varchar(MAX),
CurrentJobStatusID int


);

Create table Country 
(

CountryID int PRIMARY KEY IDENTITY (1, 1),
Country varchar(150)


);


create table JobCategory 
(
 JobCategoryID int PRIMARY KEY IDENTITY (1, 1),
 CategoryName varchar(150),
 Description varchar (500)
);


create table CurrentJobStatus 
(
 CurrentJobStatusID int PRIMARY KEY IDENTITY (1, 1),
 CurrentJobStatus varchar(150)
);



Create Table Jobs 
(
JobsID int PRIMARY KEY IDENTITY (1, 1),
JobCategoryID int,
JobTitle varchar(500),
JobRequirements varchar(MAX),
JobDetails varchar (MAX)



 );


 Create table Company (

 CompanyID int PRIMARY KEY IDENTITY (1, 1),
UserID int,
CompanyName varchar(500),
ContactNo varchar(14),
PhoneNo varchar (20),
EmailAddress varchar (500),
Logo varchar (MAX),
Description varchar (500)
 );




 Create table JobPosts
 (

 JobPostsID int PRIMARY KEY IDENTITY (1, 1),
UserID int,
CompanyID int,
JobID int ,
JobCategoryID int,
RequiredPerson int,
Qualification varchar(500),
MinimumExperience varchar(500),
AgeLimit int,
MarritalStatus varchar (20),
StartDate date,
EndDate date,
ShortlistDate date,
InterviewDate date,
JobStatusID int ,
Description varchar (500)

 );


 Create table JobStatus 
 (
 JobStatusID int PRIMARY KEY IDENTITY (1, 1),
 JobStatus varchar(250)

 )


 create table JobApply(

 JobApplyID int PRIMARY KEY IDENTITY (1, 1),
 EmployeeID int ,
 JobPostID int,
 JobApplyDateTime datetime,
 JobApplyStatusID int,
 StatusUpdateDateTime datetime,
 StatusUpdateReason varchar(250)
 



 );


 create table JobApplyStatus
 (

 JobApplyStatusID int PRIMARY KEY IDENTITY (1, 1),
 JobApplyStatus varchar(250)

 );



 Create table Languages
 (
 LanguageID int PRIMARY KEY IDENTITY (1, 1) ,
 EmployeeID int,
 LanguageName varchar(250),
 Proficiency varchar (100)
 );



 Create table Educations
 (
 EducationID int PRIMARY KEY IDENTITY (1, 1) ,
 EmployeeID int,
 CountryID int,
 InstituteName varchar(250),
 TitleOfEducation varchar (100),
 Degree varchar (250),
 FromYear date,
 ToYear date ,
 City  varchar (100)
 );


 create table Skills
 (
   SkillID int PRIMARY KEY IDENTITY (1, 1),
   EmployeeID int,
   SkillName varchar(250)

 );



 create table WorkExperiences 
 (
   WorkExperienceID int PRIMARY KEY IDENTITY (1, 1),
     EmployeeID int,
   Company varchar(500),
   Title varchar (500),
   CountryID int ,
   FromYear date,
   ToYear date ,
   Description varchar (1000)


 );


--relation and foregn key

alter table Users
add constraint FK_UserType_Users foreign key (UserTypeID)
   References UserTypes(UserTypeID)
   on delete no action
   on update no action;






