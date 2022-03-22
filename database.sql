use master
go
create database BaiTH5
go
use BaiTH5

go
create table SinhVien(
    Masv int identity (1000,1) primary key ,
    Ten_sv nvarchar(50),
    GioiTinh nvarchar(3),
    DiaChi nvarchar(100),
    NgaySinh date
)
go
create table Monhoc(
    Mamh int identity (1000,1) primary key ,
    Tenmh nvarchar(100),
    chyennganh nvarchar(100),
    Sohoctrinh nvarchar(100)
)
go
create table Giaovien(
    Magv int identity (1000,1) primary key ,
    Tengv nvarchar(100),
    chyennganh nvarchar(100),
    diachi nvarchar(100),
	sdt int
)
go
create table Bangdiem(
    Masv int ,
    Mamh int ,
    Diem int,
    constraint pk1 primary key(Masv,Mamh)
)
go
create table Gv_day(
    Magv int ,
    Mamh int,
    constraint pk2 primary key(Magv,Mamh)
  
)