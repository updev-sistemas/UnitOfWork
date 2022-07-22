create database poc_unit_of_work;

use poc_unit_of_work;

CREATE TABLE poc_unit_of_work.dbo.tb_users (
	id bigint IDENTITY(1,1) NOT NULL,
	email varchar(120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	username varchar(60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	created_at datetime2(0) NULL,
	updated_at datetime2(0) NULL
);
