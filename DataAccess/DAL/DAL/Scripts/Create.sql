CREATE TABLE TBL_URL (
    ID int IDENTITY(1,1) PRIMARY KEY,
    LONG_URL varchar(8000) null,
    SHORT_URL varchar(8000) null
);