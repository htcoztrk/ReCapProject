CREATE TABLE CarImages(
    CarImageId   INT      IDENTITY (1, 1) NOT NULL,
    CarId      INT      NULL,
    ImagePath nvarchar(200),
    CarImageDate  DATETIME NULL,
    PRIMARY KEY CLUSTERED ([CarImageId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]),
    
);
