# predica_task

### Features

- > Asp Net Core API with best practices - repository pattern and restful api.
- > open API support with bearer authentication
- > Web API authentication using Azure AD
- > Database seed using third party API - https://restcountries.eu/ as a source for countries.


### Task 2
<details>    
  <summary>Answer</summary> 
  

   ```
     CREATE SCHEMA db_appschema;

     CREATE TABLE [db_appschema].[Dimension] (
       [Id] INT IDENTITY (1, 1) NOT NULL,
       [Name] NVARCHAR (200) NULL,
       [Value] INT NULL,
       [IsDeleted] BIT NULL,
       PRIMARY KEY CLUSTERED ([Id] ASC),
       CONSTRAINT [AK_Name] UNIQUE NONCLUSTERED ([Name] ASC)
    );

    CREATE TABLE [db_appschema].[staging] (
    [Name]  VARCHAR (200) NULL,
    [Value] INT NULL   
    );

   ```
  </details>

---

### Task 3
<details>    
  <summary>Answer</summary> 
  

   ```
CREATE or ALTER PROCEDURE [dbo].LoadDimensions
AS
begin

   declare @stagename varchar(150),@dimensionName varchar(150),@stageValue int,
		@dimensionID int, @dimensionValue int, @isdeleted bit

   declare changeset3 cursor fast_forward read_only
   for
   select A.name,A.value,B.Id,B.name,B.value,B.IsDeleted
   from [db_appschema].[staging] A
   left join [db_appschema].[Dimension] B
   on A.name = B.name

   open changeset3
   fetch next from changeset3 into
   @stagename,@stageValue,@dimensionID,@dimensionName,@dimensionValue,@isdeleted


   while @@FETCH_STATUS = 0
   BEGIN
		  if (@dimensionID is null)
			begin
			  insert into [db_appschema].[Dimension]
			  values(@stagename,@stageValue,0)
			end
		  else
			begin
			  if (@stagename = @dimensionName)
					begin
					  update [db_appschema].[Dimension]
						 set value = @stageValue,IsDeleted = 0
						 where id = @dimensionID
					end    
			end

		  FETCH NEXT FROM changeset3 INTO @stagename,@stageValue,@dimensionID,@dimensionName,@dimensionValue,@isdeleted

   END

   update [db_appschema].[Dimension]
   set IsDeleted = 1
   from [db_appschema].[Dimension] d
   where not exists( select 1 from [db_appschema].[staging] s where s.name = d.name)

 close changeset3

end

   ```
  </details>

---
    
 
