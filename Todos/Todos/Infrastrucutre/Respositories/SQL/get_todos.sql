SELECT [task_id]
      ,[name]
      ,[description]
      ,[status]
      ,[created_at]
      ,[completed_at]
      ,[user_id]
  FROM [TodosDB].[dbo].[Todos] WHERE [user_id] = @userId
