IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Author')
BEGIN
    CREATE TABLE [Author] (
        [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
        [FirstName] VARCHAR(64) NOT NULL,
        [LastName] VARCHAR(64) NOT NULL,
    )

    INSERT INTO [Author] ([FirstName], [LastName])
    VALUES
    ('Stephen','King'),
    ('J.K.','Rowling'),
    ('Charles','Dickens'),
    ('Jane','Austen')

END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Book')
BEGIN
    CREATE TABLE [Book] (
        [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
        [Title] VARCHAR(256) NOT NULL,
        [YearPublished] NUMERIC NULL,
        [AuthorId] INT,
        CONSTRAINT [Book_Author_Id] FOREIGN KEY ([AuthorId]) REFERENCES Author([Id])
    )

    INSERT INTO [Book] ([Title], [YearPublished], [AuthorId])
    VALUES
    ('Pet Sematary', 1983, 1),
    ('The Dark Tower: The Gunslinger', 1982, 1),
    ('It', 1986, 1),
    ('The Dark Tower II: The Drawing of the Three', 1987, 1),
    ('Harry Potter and the Philosopher''s Stone', 1997, 2),
    ('Harry Potter and the Chamber of Secrets' , 1998, 2),
    ('Harry Potter and the Prisoner of Azkaban', 1999, 2),
    ('The Adventures of Oliver Twist', 1837, 3),
    ('A Christmas Carol', 1843, 3),
    ('A Tale of Two Cities', 1859, 3),
    ('Sense and Sensibility', 1811, 4),
    ('Pride and Prejudice', 1813, 4),
    ('Mansfield Park', 1814, 4)

END

SELECT *
FROM [Author]

SELECT * 
FROM [Book]