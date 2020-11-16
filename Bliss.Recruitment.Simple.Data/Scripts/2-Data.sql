USE Recruitment;
GO

SET IDENTITY_INSERT [Questions] ON;
GO

INSERT INTO [Questions] ([QuestionId], [Description], [ImageUrl], [ThumbUrl], [PublishedAt]) VALUES 
    (1, 'Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', '2015-08-05T08:40:51.620Z')
;
GO
INSERT INTO [Questions] ([QuestionId], [Description], [ImageUrl], [ThumbUrl], [PublishedAt]) VALUES 
    (2, 'Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', '2015-08-05T08:40:51.620Z')
;
GO
INSERT INTO [Questions] ([QuestionId], [Description], [ImageUrl], [ThumbUrl], [PublishedAt]) VALUES 
    (3, 'Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', '2015-08-05T08:40:51.620Z')
;
GO
INSERT INTO [Questions] ([QuestionId], [Description], [ImageUrl], [ThumbUrl], [PublishedAt]) VALUES 
    (4, 'Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', '2015-08-05T08:40:51.620Z')
;
GO
INSERT INTO [Questions] ([QuestionId], [Description], [ImageUrl], [ThumbUrl], [PublishedAt]) VALUES 
    (5, 'Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', '2015-08-05T08:40:51.620Z')
;
GO
INSERT INTO [Questions] ([QuestionId], [Description], [ImageUrl], [ThumbUrl], [PublishedAt]) VALUES 
    (6, 'Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', '2015-08-05T08:40:51.620Z')
;
GO

SET IDENTITY_INSERT [Questions] OFF;
GO


SET IDENTITY_INSERT [Choices] ON;
GO

INSERT INTO [Choices] ([ChoiceId], [Description], [Vote], [QuestionId]) VALUES 
    (1, 'Swift', 2048, 1),
    (2, 'Python', 1024, 1),
    (3, 'Objective-C', 512, 1),
    (4, 'Ruby', 256, 1)
;
GO
INSERT INTO [Choices] ([ChoiceId], [Description], [Vote], [QuestionId]) VALUES 
    (5, 'Swift', 2048, 2),
    (6, 'Python', 1024, 2),
    (7, 'Objective-C', 512, 2),
    (8, 'Ruby', 256, 2)
;
GO
INSERT INTO [Choices] ([ChoiceId], [Description], [Vote], [QuestionId]) VALUES 
    (9, 'Swift', 2048, 3),
    (10, 'Python', 1024, 3),
    (11, 'Objective-C', 512, 3),
    (12, 'Ruby', 256, 3)
;
GO
INSERT INTO [Choices] ([ChoiceId], [Description], [Vote], [QuestionId]) VALUES 
    (13, 'Swift', 2048, 4),
    (14, 'Python', 1024, 4),
    (15, 'Objective-C', 512, 4),
    (16, 'Ruby', 256, 4)
;
GO
INSERT INTO [Choices] ([ChoiceId], [Description], [Vote], [QuestionId]) VALUES 
    (17, 'Swift', 2048, 5),
    (18, 'Python', 1024, 5),
    (19, 'Objective-C', 512, 5),
    (20, 'Ruby', 256, 5)
;
GO
INSERT INTO [Choices] ([ChoiceId], [Description], [Vote], [QuestionId]) VALUES 
    (21, 'Swift', 2048, 6),
    (22, 'Python', 1024, 6),
    (23, 'Objective-C', 512, 6),
    (24, 'Ruby', 256, 6)
;
GO

SET IDENTITY_INSERT [Choices] OFF;
GO