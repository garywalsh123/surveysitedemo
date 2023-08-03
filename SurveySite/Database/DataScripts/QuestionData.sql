--Add the banks

DECLARE @Banks TABLE ( 
	BankId UNIQUEIDENTIFIER,
	BankDesc NVARCHAR(255)
)

INSERT INTO @Banks
VALUES 
('05164a62-63a0-46e5-9fe5-a9bc431b7120', 'General Questions'),
('e4e32f7f-2f71-4d6c-893c-dd3e746a695e', 'Political Questions'),
('3099a2c7-1640-46e4-84c0-a8a0aa479430', 'Sport Questions'),
('338fc1fe-6fd5-43bf-be8c-09f973c9381f', 'Issues Questions')


DECLARE @BankId UNIQUEIDENTIFIER
DECLARE @BankDesc NVARCHAR(255)

DECLARE Bank_Cursor CURSOR FOR  
SELECT BankId, BankDesc
FROM @Banks 

OPEN Bank_Cursor  
FETCH NEXT FROM Bank_Cursor INTO @BankId, @BankDesc
WHILE @@FETCH_STATUS = 0  
   BEGIN  
		IF NOT EXISTS (SELECT 1 FROM [dbo].[QuestionBank] WHERE QuestionBankId = @BankId)
		BEGIN
			PRINT 'Question Bank: Adding "' + @BankDesc + '"'
			
			insert into [QuestionBank]([QuestionBankId], [QuestionBankName])
			values(@BankId, @BankDesc)

		END
		ELSE
			PRINT 'Question Bank: "' + @BankDesc + '". Already exists.'
	
		FETCH NEXT FROM Bank_Cursor INTO @BankId, @BankDesc
   END  

CLOSE Bank_Cursor  

DEALLOCATE Bank_Cursor
GO

--

--Add the questions

DECLARE @Questions TABLE ( 
	QuestionId UNIQUEIDENTIFIER,
	QuestionText NVARCHAR(255),
	ActiveInd INT
)

INSERT INTO @Questions
VALUES 

--general
('94163dda-3dde-437a-9cd7-b831d521431e', 'What colour is a tennis ball?', 1),
('bc7ec436-4fc7-4790-8d98-3f8eafa18618', 'Do you think homeopathy is genuinely effective at treating illnesses?', 1),
('e695562e-9bfd-4440-8810-9f3a0b6249a8', 'Which would you prefer?', 1),

--political
('108a764b-2b0f-426a-9917-15ba1762e8cc', 'Do you think former President Donald Trump has ever committed any crimes?', 1),
('53f60f8d-491a-46b9-a66c-ce2c440dcf6b', 'Do you think Donald Trump will ever be convicted of any crime?', 1),
('5014e9ea-607c-4bf7-a6ad-6af000c89e8c', 'Do you think Donald Trump will ever serve time in prison for any crime?', 1),
('ccf5c8d7-875e-4080-bea5-e8bb85a0ef43', 'Was the 2020 presidential election fair?', 1),

--issues
('77c3a8e9-2695-495c-9157-f27d358f3f66', 'Thinking about relgion, do you consider yourself religious or not religious?', 1),
('6994112b-7641-4612-8791-d6a610f0096e', 'How strongly do you feel about this issue?', 1),
('5011ab7b-6fa1-4e0d-bb60-d953da84b4a2', 'Do you support organisations that are religious', 1),

--sport
('7c96aea5-8848-4800-bea1-471bf97b932f', 'What sport do you follow most?', 1),
('b78f56cc-d718-4bc7-acc0-91ae7c2b1bad', 'Do you consider sport to be import for children?', 1),
('d4df5863-e7d6-443a-8eaf-c6961ed72c69', 'Do you actively play sports', 1)


DECLARE @QuestionId UNIQUEIDENTIFIER
DECLARE @QuestonText NVARCHAR(255)
DECLARE @ActiveInd INT

DECLARE Question_Cursor CURSOR FOR  
SELECT QuestionId, QuestionText, ActiveInd
FROM @Questions 

OPEN Question_Cursor  
FETCH NEXT FROM Question_Cursor INTO @QuestionId, @QuestonText, @ActiveInd
WHILE @@FETCH_STATUS = 0  
   BEGIN  
		IF NOT EXISTS (SELECT 1 FROM [dbo].[question] WHERE questionid = @QuestionId)
		BEGIN
			PRINT 'Question Type: Adding "' + @QuestonText + '"'
			
			insert into question(questionid, questiontext, activeInd)
			values(@QuestionId, @QuestonText, @ActiveInd)

		END
		ELSE
			PRINT 'Question Type: "' + @QuestonText + '". Already exists.'
	
		FETCH NEXT FROM Question_Cursor INTO @QuestionId, @QuestonText, @ActiveInd
   END  

CLOSE Question_Cursor  

DEALLOCATE Question_Cursor
GO


-- Add the answers now for the questions above

DECLARE @Answers TABLE ( 
	AnswerId UNIQUEIDENTIFIER,
	QuestionId UNIQUEIDENTIFIER,
	AnswerText NVARCHAR(255),
	ActiveInd INT
)

INSERT INTO @Answers
VALUES 
--General questins
('53447411-3163-4fd2-8e1e-f738ea79a491', '94163dda-3dde-437a-9cd7-b831d521431e',		'Yellow',		1),
('224b41bc-d36a-4438-ace8-a04635a45ca3', '94163dda-3dde-437a-9cd7-b831d521431e',		'Green',		1),
('4c402587-cbbe-4b89-afa8-c0b966514de4', '94163dda-3dde-437a-9cd7-b831d521431e',		'Not Sure',		1),

('c5a947f5-40ad-470f-8bef-10eb0e6c53d0', 'bc7ec436-4fc7-4790-8d98-3f8eafa18618',		'Effective',	1),
('d92a1074-72dd-453a-895a-4748a9a3ab06', 'bc7ec436-4fc7-4790-8d98-3f8eafa18618',		'Not Effective',1),
('fa093f2f-ed6f-4170-a4ce-f84cea3d6d62', 'bc7ec436-4fc7-4790-8d98-3f8eafa18618',		'Not Sure',		1),

('19d04bb2-7fcc-4510-bf10-183a5a3acc25', 'e695562e-9bfd-4440-8810-9f3a0b6249a8',		'Honey',		1),
('1bfc6b29-a106-48f5-a628-84fd97100626', 'e695562e-9bfd-4440-8810-9f3a0b6249a8',		'Mustard',		1),
('0073d41f-0982-4106-8b66-0c31c85229c5', 'e695562e-9bfd-4440-8810-9f3a0b6249a8',		'ketchup',		1),


--Political
('2b7611a8-4df6-489b-9804-7a0a2abd38de', 'ccf5c8d7-875e-4080-bea5-e8bb85a0ef43',		'Yes',			1),
('1a2650b4-3f89-4de4-a13c-13b691b2ec38', 'ccf5c8d7-875e-4080-bea5-e8bb85a0ef43',		'No',			1),
('ed4f749a-24e7-4ec7-ad7c-82bf0d3dbee6', 'ccf5c8d7-875e-4080-bea5-e8bb85a0ef43',		'Not Sure',		1),

('0d7a8376-bd4b-45be-8b19-762ed0366cdc', '5014e9ea-607c-4bf7-a6ad-6af000c89e8c',		'Yes',			1),
('0c7781d1-0d06-41d9-91b2-e19604bc149f', '5014e9ea-607c-4bf7-a6ad-6af000c89e8c',		'No',			1),
('b37db817-636f-4b26-8ec7-9dce47a8c9f0', '5014e9ea-607c-4bf7-a6ad-6af000c89e8c',		'Not Sure',		1),

('90245d30-52cc-49b8-8652-7912134f077f', '53f60f8d-491a-46b9-a66c-ce2c440dcf6b',		'Yes',			1),
('da5e65cf-b1b0-44f5-8d89-655741628cef', '53f60f8d-491a-46b9-a66c-ce2c440dcf6b',		'No',			1),
('8b398b72-bdf1-464a-8031-4c9374be63e1', '53f60f8d-491a-46b9-a66c-ce2c440dcf6b',		'Not Sure',		1),

('fb19deb6-be1a-4bbe-8518-296d1060b15a', '108a764b-2b0f-426a-9917-15ba1762e8cc',		'Yes',			1),
('c2a838bf-6e85-42f3-be71-10a1115d7722', '108a764b-2b0f-426a-9917-15ba1762e8cc',		'No',			1),
('8e02056a-395d-4af5-a49b-82d4a80d806e', '108a764b-2b0f-426a-9917-15ba1762e8cc',		'Not Sure',		1),

--issues
('5af23873-27c0-4605-ba9a-4ed6765c8762', '77c3a8e9-2695-495c-9157-f27d358f3f66',		'Yes',			1),
('4a1bcc24-f9c5-48cb-8568-bbd91d1497a8', '77c3a8e9-2695-495c-9157-f27d358f3f66',		'No',			1),
('0cb19c8f-5a41-45a6-9b26-7ddcb5ff49b8', '77c3a8e9-2695-495c-9157-f27d358f3f66',		'Somewhat',		1),

('60e1e057-abc1-408e-9da8-77faa709d846', '6994112b-7641-4612-8791-d6a610f0096e',		'Strongly',		1),
('837216ff-4d36-433f-a533-6abfe2aa84c6', '6994112b-7641-4612-8791-d6a610f0096e',		'Not Strongly', 1),
('668492f4-0c97-4aa2-94ae-d08ce57323f2', '6994112b-7641-4612-8791-d6a610f0096e',		'Dont Care',	1),

('ce1b2691-4363-4fe1-9f5c-78a6c4ec3645', '5011ab7b-6fa1-4e0d-bb60-d953da84b4a2',		'Yes',			1),
('f8237059-b2ba-4144-9bdb-3c47bd97221b', '5011ab7b-6fa1-4e0d-bb60-d953da84b4a2',		'No',			1),

--sport
('2b8589d7-b115-4545-9289-44ced6fb4724', '7C96AEA5-8848-4800-BEA1-471BF97B932F',		'Soccer',				1),
('e9551890-5277-4437-83b7-205132140715', '7C96AEA5-8848-4800-BEA1-471BF97B932F',		'Rugby',				1),
('b2c05eb4-4e9c-4816-9b4c-2e5215949366', '7C96AEA5-8848-4800-BEA1-471BF97B932F',		'Gaelic Football',		1),

('944cf6f8-5296-453a-8957-c81e3b5799e1', 'B78F56CC-D718-4BC7-ACC0-91AE7C2B1BAD',		'Yes',			1),
('ed2b2cb8-b252-451d-b094-3676b5120880', 'B78F56CC-D718-4BC7-ACC0-91AE7C2B1BAD',		'No',			1),
('52572aaf-a5d2-4901-8637-035f2260efaf', 'B78F56CC-D718-4BC7-ACC0-91AE7C2B1BAD',		'Somewhat',		1),

('d08cdd3f-6e89-4ea4-8490-4c85d4eb4527', 'D4DF5863-E7D6-443A-8EAF-C6961ED72C69',		'Yes',			1),
('b0dc65da-956c-4b8e-ac9c-f2635e649caa', 'D4DF5863-E7D6-443A-8EAF-C6961ED72C69',		'No',			1)

DECLARE @AnswerId UNIQUEIDENTIFIER
DECLARE @QuestionId UNIQUEIDENTIFIER
DECLARE @AnswerText NVARCHAR(255)
DECLARE @ActiveInd INT

DECLARE Answer_Cursor CURSOR FOR  
SELECT AnswerId, QuestionId, AnswerText, ActiveInd
FROM @Answers 

OPEN Answer_Cursor  
FETCH NEXT FROM Answer_Cursor INTO @AnswerId, @QuestionId, @AnswerText, @ActiveInd
WHILE @@FETCH_STATUS = 0  
   BEGIN  
		IF NOT EXISTS (SELECT 1 FROM [dbo].[answer] WHERE answerid = @AnswerId)
		BEGIN
			PRINT 'Answer Adding "' + @AnswerText + '"'
			
			insert into answer(answerid, questionid, answertext, activeInd)
			values(@AnswerId, @QuestionId,@AnswerText , @ActiveInd)

		END
		ELSE
			PRINT 'Answer Type: "' + @AnswerText + '". Already exists.'
	
		FETCH NEXT FROM Answer_Cursor INTO @AnswerId, @QuestionId, @AnswerText, @ActiveInd
   END  
CLOSE Answer_Cursor  

DEALLOCATE Answer_Cursor
GO



--Add questions to banks


DECLARE @QuestionBanks TABLE ( 
	QuestionBankId UNIQUEIDENTIFIER,
	QuestionId UNIQUEIDENTIFIER
)



INSERT INTO @QuestionBanks
VALUES 
--general
('05164a62-63a0-46e5-9fe5-a9bc431b7120', '94163dda-3dde-437a-9cd7-b831d521431e'),
('05164a62-63a0-46e5-9fe5-a9bc431b7120', 'bc7ec436-4fc7-4790-8d98-3f8eafa18618'),
('05164a62-63a0-46e5-9fe5-a9bc431b7120', 'e695562e-9bfd-4440-8810-9f3a0b6249a8'),

--political
('e4e32f7f-2f71-4d6c-893c-dd3e746a695e', 'ccf5c8d7-875e-4080-bea5-e8bb85a0ef43'),
('e4e32f7f-2f71-4d6c-893c-dd3e746a695e', '108a764b-2b0f-426a-9917-15ba1762e8cc'),
('e4e32f7f-2f71-4d6c-893c-dd3e746a695e', '53f60f8d-491a-46b9-a66c-ce2c440dcf6b'),
('e4e32f7f-2f71-4d6c-893c-dd3e746a695e', '5014e9ea-607c-4bf7-a6ad-6af000c89e8c'),

--sport
('3099a2c7-1640-46e4-84c0-a8a0aa479430', 'B78F56CC-D718-4BC7-ACC0-91AE7C2B1BAD'),
('3099a2c7-1640-46e4-84c0-a8a0aa479430', 'D4DF5863-E7D6-443A-8EAF-C6961ED72C69'),
('3099a2c7-1640-46e4-84c0-a8a0aa479430', '7C96AEA5-8848-4800-BEA1-471BF97B932F'),

--issues
('338fc1fe-6fd5-43bf-be8c-09f973c9381f', '77C3A8E9-2695-495C-9157-F27D358F3F66'),
('338fc1fe-6fd5-43bf-be8c-09f973c9381f', '5011AB7B-6FA1-4E0D-BB60-D953DA84B4A2'),
('338fc1fe-6fd5-43bf-be8c-09f973c9381f', '6994112B-7641-4612-8791-D6A610F0096E')


DECLARE @QuestionBankId UNIQUEIDENTIFIER
DECLARE @QuestionId UNIQUEIDENTIFIER

DECLARE QB_Cursor CURSOR FOR  
SELECT QuestionBankId, QuestionId
FROM @QuestionBanks 

OPEN QB_Cursor  
FETCH NEXT FROM QB_Cursor INTO @QuestionBankId, @QuestionId
WHILE @@FETCH_STATUS = 0  
   BEGIN  
		IF NOT EXISTS (SELECT 1 FROM [dbo].[QuestionQuestionBank] WHERE QuestionBanksQuestionBankId = @QuestionBankId AND QuestionsQuestionId = @QuestionId)
		BEGIN
			

			insert into [QuestionQuestionBank](QuestionBanksQuestionBankId, QuestionsQuestionId)
			values
			(@QuestionBankId, @QuestionId)


		END
	
		FETCH NEXT FROM QB_Cursor INTO @QuestionBankId, @QuestionId
   END  
CLOSE QB_Cursor  

DEALLOCATE QB_Cursor
GO


