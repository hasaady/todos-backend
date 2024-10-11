UPDATE [dbo].[Todos]
   SET [name] = @name
      ,[description] = @description
      ,[status] = @status
      ,[created_at] = @created_at
      ,[completed_at] = @completed_at
 WHERE [task_id] = @id