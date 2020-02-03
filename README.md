# Telledge
これは英語版のドキュメントです。日本語版が必要な場合は[こちら](./README.ja.md)を参照してください。  
This is a English documentation for the project, look [here](./README.ja.md) if you need Japanese one.

## Introduction
The system provide many opportunities to be a teacher to everyone.  
Or, can be learning skills a lot as student.  
Our skills will be beyond previous!  

## Why using Telledge?
In the world, there are many platforms for learning things.  
For example, Youtube, Twitter, blogs, etc...  
We think they are providing "just" informations.  
But Telledge would provide informations as knowlledge.  
There are huge difference between information and knowlledge.  
We hope you get information as knowlledge through the system!

## Required
Operation System :  Windows 10  
Envirnment : Visual Studio that 2017, or later.  

## Installation
Follow these steps.
1. Clone from our repository.
2. Set up some setting files.  
	2-1. Create an `Authentication.config` to your telledge directory at repository root.  
		This is example for you. So you have to change it with your environment.  
	   
		<?xml version="1.0"?>  
		<connectionStrings>  
    		<add name="Db" connectionString="Data Source=TypeYourDBHost;Initial Catalog= TypeYourCatalog;User ID = TypeYourId;Password=TypeYourPassword" />  
		</connectionStrings>  
	     
	2-2. Create an `App.config` to your UnitTest directory at repository root.  
		This is example for you. So you have to change it with your environment.  
	   
	<?xml version="1.0" encoding="utf-8" ?>
	<configuration>
		<appSettings>

		</appSettings>

		<connectionStrings>
		  <add name="Db" connectionString="Data Source=TypeYourDBHost;Initial Catalog= TypeYourCatalog;User ID = TypeYourId;Password=TypeYourPassword" /> 
		</connectionStrings>
	</configuration>


## Usage for teacher
Login as a teacher.  
After create your room, wait until coming studnet who want to lean from you.  
During calling with your studnet, teach your knowlledge.  
End of call, push a button to stop calling and take a break.  
The next studnet waiting your class.  

## Usage for student
Login as a studnet.  
Select a room that you are interested from a list of rooms, or search by specific tags or something options(not implemented).    
After joined a room, wait until your teacher start calling with you.  
If you prefer the teacher, put on five stars at valuaton page :)  

## License
[Open license](./LICENSE)
