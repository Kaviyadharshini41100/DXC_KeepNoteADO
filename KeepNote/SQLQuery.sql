Create database KeepNotes
use KeepNotes
Create Table takeNote(
Id int identity primary key,
Title varchar(30),
Descriptions varchar(80),
Dates datetime
)
select * from takeNote
