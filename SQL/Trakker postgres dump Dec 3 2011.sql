/*
Navicat PGSQL Data Transfer

Source Server         : Postgres
Source Server Version : 90101
Source Host           : 192.168.1.69:5432
Source Database       : Trakker
Source Schema         : public

Target Server Type    : PGSQL
Target Server Version : 90101
File Encoding         : 65001

Date: 2011-12-03 20:05:00
*/


-- ----------------------------
-- Sequence structure for "public"."ColorPalette_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."ColorPalette_Id_seq";
CREATE SEQUENCE "public"."ColorPalette_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."Comment_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."Comment_Id_seq";
CREATE SEQUENCE "public"."Comment_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."Component_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."Component_Id_seq";
CREATE SEQUENCE "public"."Component_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."ComponentTicket_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."ComponentTicket_Id_seq";
CREATE SEQUENCE "public"."ComponentTicket_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."File_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."File_Id_seq";
CREATE SEQUENCE "public"."File_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."Project_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."Project_Id_seq";
CREATE SEQUENCE "public"."Project_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."ProjectVersion_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."ProjectVersion_Id_seq";
CREATE SEQUENCE "public"."ProjectVersion_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 101
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."Property_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."Property_Id_seq";
CREATE SEQUENCE "public"."Property_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."Role_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."Role_Id_seq";
CREATE SEQUENCE "public"."Role_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."Ticket_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."Ticket_Id_seq";
CREATE SEQUENCE "public"."Ticket_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."TicketFixedOnVersion_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."TicketFixedOnVersion_Id_seq";
CREATE SEQUENCE "public"."TicketFixedOnVersion_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."TicketFoundOnVersion_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."TicketFoundOnVersion_Id_seq";
CREATE SEQUENCE "public"."TicketFoundOnVersion_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."TicketPriority_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."TicketPriority_Id_seq";
CREATE SEQUENCE "public"."TicketPriority_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."TicketResolution_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."TicketResolution_Id_seq";
CREATE SEQUENCE "public"."TicketResolution_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."TicketStatus_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."TicketStatus_Id_seq";
CREATE SEQUENCE "public"."TicketStatus_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."TicketType_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."TicketType_Id_seq";
CREATE SEQUENCE "public"."TicketType_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."User_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."User_Id_seq";
CREATE SEQUENCE "public"."User_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Sequence structure for "public"."WorkLog_Id_seq"
-- ----------------------------
DROP SEQUENCE "public"."WorkLog_Id_seq";
CREATE SEQUENCE "public"."WorkLog_Id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 100
 CACHE 1;

-- ----------------------------
-- Table structure for "public"."ColorPalette"
-- ----------------------------
DROP TABLE "public"."ColorPalette";
CREATE TABLE "public"."ColorPalette" (
"Id" int4 DEFAULT nextval('"ColorPalette_Id_seq"'::regclass) NOT NULL,
"NavBackgroundColor" char(6) NOT NULL,
"SubNavBackgroundColor" char(6) NOT NULL,
"HighlightColor" char(6) NOT NULL,
"NavTextColor" char(6) NOT NULL,
"SubNavTextColor" char(6) NOT NULL,
"LinkColor" char(6) NOT NULL,
"Name" char(50) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of ColorPalette
-- ----------------------------
INSERT INTO "public"."ColorPalette" VALUES ('3', '23558F', '86B6EF', 'EFF6FF', 'ffffff', 'ffffff', '3F4FFF', 'Cuddle                                            ');
INSERT INTO "public"."ColorPalette" VALUES ('5', '777   ', '222   ', '222   ', '222   ', '222   ', '222   ', 'Rainbow                                           ');
INSERT INTO "public"."ColorPalette" VALUES ('12', '123123', '123123', '123123', '123123', '123123', '123123', 'Rainbowsss                                        ');
INSERT INTO "public"."ColorPalette" VALUES ('13', '7f4f2d', '123   ', '123   ', '123   ', '123   ', '123   ', 'Asdas A Daaadasd Asdadsda                         ');
INSERT INTO "public"."ColorPalette" VALUES ('14', '123   ', '123   ', '123   ', '123   ', '123   ', '123   ', 'Rainbows                                          ');

-- ----------------------------
-- Table structure for "public"."Comment"
-- ----------------------------
DROP TABLE "public"."Comment";
CREATE TABLE "public"."Comment" (
"Id" int4 DEFAULT nextval('"Comment_Id_seq"'::regclass) NOT NULL,
"Body" text NOT NULL,
"Created" timestamp(6) NOT NULL,
"Modified" timestamp(6) NOT NULL,
"TicketId" int4 NOT NULL,
"UserId" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of Comment
-- ----------------------------
INSERT INTO "public"."Comment" VALUES ('2', 'asda dadada', '2011-02-26 00:00:00', '2011-02-26 00:00:00', '21', '13');
INSERT INTO "public"."Comment" VALUES ('3', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In non dolor est, in ultricies urna. Sed condimentum quam nec sem iaculis quis elementum lacus vestibulum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean pretium, ante non fringilla consectetur, sapien turpis consequat arcu, eleifend pretium lectus arcu ac lectus. Aliquam erat mi, convallis vel tristique sed, congue a purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse in neque et enim tempor pretium nec ac leo. Suspendisse semper adipiscing aliquam. Sed venenatis vestibulum libero, quis cursus arcu cursus quis. In hac habitasse platea dictumst. Aliquam nec urna dui, at congue risus. Fusce iaculis tempus diam sit amet gravida. Maecenas hendrerit porta arcu quis interdum. Donec consequat, justo in placerat lobortis, libero metus tempor urna, eget porta eros mi in turpis. Vivamus varius est laoreet magna fringilla ac sagittis libero sodales.\r\n\r\nFusce urna mauris, laoreet sit amet condimentum nec, vulputate vel dolor. Sed vitae purus in lorem sagittis venenatis. Fusce condimentum enim at sem semper dignissim. Etiam eleifend dignissim quam, et luctus mauris feugiat quis. Cras vel mauris sit amet est eleifend varius. Praesent orci est, ultrices in posuere sed, imperdiet sit amet elit. Aliquam vel sapien magna, molestie ultricies eros. Suspendisse ullamcorper, leo vitae varius auctor, libero lacus lacinia nunc, eget vestibulum elit odio id eros. Curabitur neque nisi, vulputate et scelerisque eu, malesuada vel leo. Sed quis mi nec felis semper sollicitudin at a augue. Sed non sapien id massa vehicula volutpat. Aliquam erat volutpat. Suspendisse vel massa eu sapien tincidunt malesuada non in tellus.\r\n\r\nSed hendrerit bibendum sem et interdum. Suspendisse porta interdum ante, in ornare orci dictum et. Quisque vestibulum laoreet leo eu laoreet. Nullam dolor lacus, feugiat in malesuada non, iaculis ultricies augue. Integer consequat purus id eros convallis vulputate suscipit tellus dapibus. Praesent vel tincidunt libero. Phasellus molestie mattis cursus. Sed vel dignissim enim. Proin elementum tempus tincidunt. In leo libero, tristique fermentum tempor et, tincidunt tristique magna. Aliquam malesuada eros vel lacus commodo gravida. Donec porta metus a ligula condimentum et pharetra arcu tempus. In euismod risus a elit pulvinar interdum. Quisque aliquam metus in risus fermentum dignissim. Phasellus nibh diam, euismod non facilisis ut, facilisis quis nisl. ', '2011-03-05 00:00:00', '2011-03-05 00:00:00', '21', '13');
INSERT INTO "public"."Comment" VALUES ('4', 'asdasd asdsad ', '2011-03-15 00:08:59', '2011-03-15 00:08:59', '22', '13');
INSERT INTO "public"."Comment" VALUES ('5', 'sadasd ad adas dad s', '2011-03-15 00:13:59', '2011-03-15 00:13:59', '21', '13');
INSERT INTO "public"."Comment" VALUES ('6', 'asda da  das', '2011-03-15 00:18:53', '2011-03-15 00:18:53', '22', '13');
INSERT INTO "public"."Comment" VALUES ('7', 'asda dads asdas', '2011-03-15 00:22:12', '2011-03-15 00:22:12', '21', '13');
INSERT INTO "public"."Comment" VALUES ('8', 'sdjakd akdj akdj akdj ad ad asdadads', '2011-03-15 00:24:19', '2011-03-15 00:24:19', '21', '13');

-- ----------------------------
-- Table structure for "public"."Component"
-- ----------------------------
DROP TABLE "public"."Component";
CREATE TABLE "public"."Component" (
"Id" int4 DEFAULT nextval('"Component_Id_seq"'::regclass) NOT NULL,
"Name" varchar(150) NOT NULL,
"Created" timestamp(6) NOT NULL,
"Description" text NOT NULL,
"TicketId" int4 NOT NULL,
"ProjectId" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of Component
-- ----------------------------

-- ----------------------------
-- Table structure for "public"."ComponentTicket"
-- ----------------------------
DROP TABLE "public"."ComponentTicket";
CREATE TABLE "public"."ComponentTicket" (
"Id" int4 DEFAULT nextval('"ComponentTicket_Id_seq"'::regclass) NOT NULL,
"ComponentId" int4 NOT NULL,
"TicketId" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of ComponentTicket
-- ----------------------------

-- ----------------------------
-- Table structure for "public"."File"
-- ----------------------------
DROP TABLE "public"."File";
CREATE TABLE "public"."File" (
"Id" int4 DEFAULT nextval('"File_Id_seq"'::regclass) NOT NULL,
"FileName" varchar(50) NOT NULL,
"Path" text NOT NULL,
"ContentType" varchar(20) NOT NULL,
"Uploaded" timestamp(6) NOT NULL,
"ContentLength" int8 NOT NULL,
"Usage" int2 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of File
-- ----------------------------
INSERT INTO "public"."File" VALUES ('1', 'Test', 'Test', 'text/jpg', '2000-12-12 00:00:00', '123', '0');

-- ----------------------------
-- Table structure for "public"."Project"
-- ----------------------------
DROP TABLE "public"."Project";
CREATE TABLE "public"."Project" (
"Id" int4 DEFAULT nextval('"Project_Id_seq"'::regclass) NOT NULL,
"Name" varchar(100) NOT NULL,
"Lead" int4 NOT NULL,
"KeyName" varchar(20) NOT NULL,
"Due" date,
"Created" timestamp(6) NOT NULL,
"TicketIndex" int4 NOT NULL,
"Url" varchar(200) NOT NULL,
"ColorPaletteId" int4 NOT NULL,
"AvatarId" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of Project
-- ----------------------------
INSERT INTO "public"."Project" VALUES ('1', 'I has lots of ticketss', '2', 'IHLTHH', '0018-01-01', '2010-05-10 23:30:32', '26', 'http://asdadasd.com?s=asda', '3', '1');
INSERT INTO "public"."Project" VALUES ('2', 'Sara Romano', '2', 'SR', '0015-10-31', '2010-05-10 00:49:20', '21', 'www.google.ca', '3', '1');
INSERT INTO "public"."Project" VALUES ('9', 'Clean Up', '2', 'CU', '0015-10-31', '2010-05-10 01:02:49', '20', 'zasd', '3', '1');
INSERT INTO "public"."Project" VALUES ('10', 'I really like it', '9', 'DDD', '0016-04-01', '2010-10-10 00:00:00', '22', 'asdasdad', '3', '1');
INSERT INTO "public"."Project" VALUES ('12', 'Molly Project', '7', 'MP', '0007-05-03', '2010-11-09 00:31:26', '0', 'lmgtfy.com/molly', '3', '1');
INSERT INTO "public"."Project" VALUES ('14', 'Another crappy project', '8', 'ACP', '0024-05-02', '2010-11-19 00:39:27', '0', 'www.google.ca', '3', '1');
INSERT INTO "public"."Project" VALUES ('15', 'Test color palettes', '2', 'TCP', '0018-06-03', '2011-06-18 21:49:26', '0', 'www.google.ca', '3', '1');
INSERT INTO "public"."Project" VALUES ('16', 'I like projects', '2', 'ILP', '0018-06-03', '2011-06-29 22:59:44', '0', 'http://www.gasdad', '13', '1');

-- ----------------------------
-- Table structure for "public"."ProjectVersion"
-- ----------------------------
DROP TABLE "public"."ProjectVersion";
CREATE TABLE "public"."ProjectVersion" (
"Id" int4 DEFAULT nextval('"ProjectVersion_Id_seq"'::regclass) NOT NULL,
"Name" varchar(50) NOT NULL,
"Description" varchar(250) NOT NULL,
"ReleaseDate" date,
"ProjectId" int4 NOT NULL,
"IsReleased" bool NOT NULL,
"SortOrder" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of ProjectVersion
-- ----------------------------
INSERT INTO "public"."ProjectVersion" VALUES ('1', '1.0.1', 'The first!', null, '1', 't', '0');
INSERT INTO "public"."ProjectVersion" VALUES ('2', '1.1', 'Minor Iteration', null, '1', 'f', '3');
INSERT INTO "public"."ProjectVersion" VALUES ('3', '1.2.1', 'Minor Iteration sadsadsa', null, '1', 't', '7');
INSERT INTO "public"."ProjectVersion" VALUES ('22', '1.1.1', 'sadasda', '2011-11-22', '1', 'f', '6');
INSERT INTO "public"."ProjectVersion" VALUES ('23', '1.1.2', 'sadasd', null, '1', 'f', '5');
INSERT INTO "public"."ProjectVersion" VALUES ('24', '1.1.3', 'asdasd', null, '1', 'f', '4');
INSERT INTO "public"."ProjectVersion" VALUES ('100', 'testing', 'I like desc', '2011-12-29', '2', 'f', '1');
INSERT INTO "public"."ProjectVersion" VALUES ('101', 'testing 2', 'sadasdasd', '2011-12-15', '2', 'f', '0');

-- ----------------------------
-- Table structure for "public"."Property"
-- ----------------------------
DROP TABLE "public"."Property";
CREATE TABLE "public"."Property" (
"Id" int4 DEFAULT nextval('"Property_Id_seq"'::regclass) NOT NULL,
"Identifier" varchar(50) NOT NULL,
"Name" varchar(50) NOT NULL,
"Value" varchar(100) NOT NULL,
"Created" timestamp(6) NOT NULL,
"Type" varchar(100) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of Property
-- ----------------------------
INSERT INTO "public"."Property" VALUES ('1', 'ColorPaletteId', 'Color Palette Id', '5', '2010-10-10 00:00:00', 'integer');

-- ----------------------------
-- Table structure for "public"."Role"
-- ----------------------------
DROP TABLE "public"."Role";
CREATE TABLE "public"."Role" (
"Id" int4 DEFAULT nextval('"Role_Id_seq"'::regclass) NOT NULL,
"Name" varchar(150) NOT NULL,
"Description" text NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of Role
-- ----------------------------
INSERT INTO "public"."Role" VALUES ('2', 'Administrator', 'Admin');

-- ----------------------------
-- Table structure for "public"."Ticket"
-- ----------------------------
DROP TABLE "public"."Ticket";
CREATE TABLE "public"."Ticket" (
"Id" int4 DEFAULT nextval('"Ticket_Id_seq"'::regclass) NOT NULL,
"TypeId" int4 NOT NULL,
"Summary" varchar(150) NOT NULL,
"PriorityId" int4 NOT NULL,
"Description" text NOT NULL,
"Created" timestamp(6) NOT NULL,
"DueDate" timestamp(6),
"StatusId" int4 NOT NULL,
"ResolutionId" int4 NOT NULL,
"IsClosed" bool NOT NULL,
"AssignedToUserId" int4 NOT NULL,
"CreatedByUserId" int4 NOT NULL,
"AssignedByUserId" int4 NOT NULL,
"ProjectId" int4 NOT NULL,
"KeyName" varchar(100) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of Ticket
-- ----------------------------
INSERT INTO "public"."Ticket" VALUES ('21', '1', 'asd asdkja kdja dkaljd akldj akldj akdlaj dkald jakld jakldj akldj akldj aklda dkla jdklajd akldj akldj akldj k', '1', 'Yeah!', '2010-04-28 23:00:53', '2010-04-28 00:00:00', '1', '1', 't', '2', '2', '2', '1', 'IHLThh-10');
INSERT INTO "public"."Ticket" VALUES ('22', '1', 'lalalaa', '1', 'lalala', '2010-04-28 23:01:35', '2010-04-28 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLT-2');
INSERT INTO "public"."Ticket" VALUES ('23', '1', 'Shit has hit the fan', '1', 'fix it!', '2010-05-19 00:14:55', '2010-05-19 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-1');
INSERT INTO "public"."Ticket" VALUES ('25', '1', 'More shit hit the fan', '1', 'adasd', '2010-05-19 00:15:14', '2010-05-19 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-2');
INSERT INTO "public"."Ticket" VALUES ('29', '1', 'sadadas', '1', '', '2010-05-19 00:37:16', '2010-05-19 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-3');
INSERT INTO "public"."Ticket" VALUES ('31', '1', 'sadadasdada', '1', '', '2010-05-19 00:42:52', '2010-05-19 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-4');
INSERT INTO "public"."Ticket" VALUES ('32', '1', 'asdadas', '1', '', '2010-05-19 01:08:15', '2010-05-19 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-5');
INSERT INTO "public"."Ticket" VALUES ('33', '1', 'sadadads', '1', 'asdad', '2010-05-19 01:13:13', '2010-05-19 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-19');
INSERT INTO "public"."Ticket" VALUES ('36', '1', 'Test after styling', '1', 'sad asdajhd adj akdj akd jada da', '2010-10-19 00:05:55', '2010-10-19 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-7');
INSERT INTO "public"."Ticket" VALUES ('37', '1', 'adad', '1', '', '2010-10-21 20:55:44', '2010-01-01 00:00:00', '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-8');
INSERT INTO "public"."Ticket" VALUES ('38', '1', 'sadasd', '1', '', '2010-10-21 21:20:07', null, '1', '1', 't', '2', '2', '2', '1', 'IHLThh-9');
INSERT INTO "public"."Ticket" VALUES ('39', '1', 'Yay dates work with nulls', '1', '', '2010-10-21 21:20:21', null, '1', '1', 't', '2', '2', '2', '1', 'IHLThh-11');
INSERT INTO "public"."Ticket" VALUES ('40', '1', 'Ticket test', '1', '', '2010-10-23 12:22:04', '2010-03-03 00:00:00', '1', '1', 't', '2', '2', '2', '1', 'IHLThh-12');
INSERT INTO "public"."Ticket" VALUES ('41', '1', 'dsadasd', '1', '', '2010-10-23 15:22:23', null, '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-13');
INSERT INTO "public"."Ticket" VALUES ('42', '1', 'ZOMG ANOTHER TICKET', '1', 'dsadsa', '2010-10-23 15:22:48', null, '1', '1', 'f', '2', '2', '2', '1', 'IHLThh-14');
INSERT INTO "public"."Ticket" VALUES ('43', '1', 'yeah!', '1', 'asdasd', '2010-10-24 23:56:07', '2010-10-07 00:00:00', '1', '1', 'f', '12', '12', '12', '1', 'IHLThh-15');
INSERT INTO "public"."Ticket" VALUES ('44', '1', 'sadadad adsa', '1', 'asd adas', '2010-10-25 00:33:30', null, '1', '1', 'f', '12', '12', '12', '1', 'IHLThh-16');
INSERT INTO "public"."Ticket" VALUES ('45', '1', 'test resolution and assigned to', '1', 'asdasda', '2010-10-25 00:35:05', '2010-10-21 00:00:00', '1', '1', 'f', '12', '12', '12', '1', 'IHLThh-17');
INSERT INTO "public"."Ticket" VALUES ('46', '1', 'clean some stuff', '4', 'asdasd', '2010-11-01 23:30:18', '2010-11-09 00:00:00', '1', '1', 'f', '2', '12', '12', '9', 'CU-1');
INSERT INTO "public"."Ticket" VALUES ('47', '1', 'testing keyname', '1', '', '2010-11-04 23:59:05', null, '1', '1', 'f', '2', '12', '12', '1', 'IHLThh-18');
INSERT INTO "public"."Ticket" VALUES ('48', '1', 'testing keyname', '1', 'sadad', '2010-11-05 00:01:53', '2010-11-01 00:00:00', '1', '1', 'f', '2', '12', '12', '1', 'IHLThh-21');
INSERT INTO "public"."Ticket" VALUES ('49', '1', 'adasdas', '1', 'asdasdsa', '2010-11-05 23:28:53', null, '1', '1', 'f', '6', '12', '12', '10', 'ddd-22');
INSERT INTO "public"."Ticket" VALUES ('50', '1', 'test', '1', '', '2010-11-06 17:19:27', '2010-11-10 00:00:00', '1', '1', 'f', '2', '12', '12', '1', 'IHLThh-24');
INSERT INTO "public"."Ticket" VALUES ('51', '1', 'ANother summary', '1', '', '2010-11-26 00:33:08', null, '1', '1', 'f', '2', '13', '13', '1', 'IHLTHH-25');
INSERT INTO "public"."Ticket" VALUES ('52', '1', 'asldkjas lkdj akdj', '1', '', '2010-12-04 02:32:22', null, '1', '1', 'f', '2', '13', '13', '1', 'IHLTHH-26');
INSERT INTO "public"."Ticket" VALUES ('53', '1', 'Must hit that', '1', 'then cuddle!!1!1!!1!!!', '2011-02-16 23:50:38', '2011-02-16 00:00:00', '1', '1', 'f', '13', '13', '13', '2', 'SR-21');

-- ----------------------------
-- Table structure for "public"."TicketFixedOnVersion"
-- ----------------------------
DROP TABLE "public"."TicketFixedOnVersion";
CREATE TABLE "public"."TicketFixedOnVersion" (
"Id" int4 DEFAULT nextval('"TicketFixedOnVersion_Id_seq"'::regclass) NOT NULL,
"TicketId" int4 NOT NULL,
"VersionId" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of TicketFixedOnVersion
-- ----------------------------
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('1', '21', '1');
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('4', '22', '1');
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('5', '23', '1');
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('6', '38', '2');
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('7', '39', '2');
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('8', '40', '2');
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('13', '41', '2');
INSERT INTO "public"."TicketFixedOnVersion" VALUES ('14', '39', '3');

-- ----------------------------
-- Table structure for "public"."TicketFoundOnVersion"
-- ----------------------------
DROP TABLE "public"."TicketFoundOnVersion";
CREATE TABLE "public"."TicketFoundOnVersion" (
"Id" int4 DEFAULT nextval('"TicketFoundOnVersion_Id_seq"'::regclass) NOT NULL,
"TicketId" int4 NOT NULL,
"VersionId" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of TicketFoundOnVersion
-- ----------------------------

-- ----------------------------
-- Table structure for "public"."TicketPriority"
-- ----------------------------
DROP TABLE "public"."TicketPriority";
CREATE TABLE "public"."TicketPriority" (
"Id" int4 DEFAULT nextval('"TicketPriority_Id_seq"'::regclass) NOT NULL,
"Name" varchar(50) NOT NULL,
"Description" varchar(250) NOT NULL,
"HexColor" char(6) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of TicketPriority
-- ----------------------------
INSERT INTO "public"."TicketPriority" VALUES ('1', 'Priority 1', 'adlkajdkla', 'FF43F1');
INSERT INTO "public"."TicketPriority" VALUES ('4', 'High', 'This is high priority', 'hF34H5');
INSERT INTO "public"."TicketPriority" VALUES ('5', 'Very Very Low', 'Just ignore it really.', '123322');
INSERT INTO "public"."TicketPriority" VALUES ('6', 'Very High', 'Very high description', '676767');
INSERT INTO "public"."TicketPriority" VALUES ('7', 'Very Very Very Low', 'sd asdkja sdkasdad', '123123');

-- ----------------------------
-- Table structure for "public"."TicketResolution"
-- ----------------------------
DROP TABLE "public"."TicketResolution";
CREATE TABLE "public"."TicketResolution" (
"Id" int4 DEFAULT nextval('"TicketResolution_Id_seq"'::regclass) NOT NULL,
"Name" varchar(50) NOT NULL,
"Description" varchar(250) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of TicketResolution
-- ----------------------------
INSERT INTO "public"."TicketResolution" VALUES ('1', 'Fixed', 'The ticket was fixed.');
INSERT INTO "public"."TicketResolution" VALUES ('2', 'Won''t Fix', 'This ticket will not get fixed.');
INSERT INTO "public"."TicketResolution" VALUES ('3', 'Broke it more', 'Oh noes :(');
INSERT INTO "public"."TicketResolution" VALUES ('4', 'Duplicate', 'This ticket is the same as another ticket');
INSERT INTO "public"."TicketResolution" VALUES ('6', 'Fixed Itself', 'Test');

-- ----------------------------
-- Table structure for "public"."TicketStatus"
-- ----------------------------
DROP TABLE "public"."TicketStatus";
CREATE TABLE "public"."TicketStatus" (
"Id" int4 DEFAULT nextval('"TicketStatus_Id_seq"'::regclass) NOT NULL,
"Name" varchar(50) NOT NULL,
"Description" varchar(250) NOT NULL,
"IsClosedState" bool NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of TicketStatus
-- ----------------------------
INSERT INTO "public"."TicketStatus" VALUES ('1', 'Code Review', 'This ticket has been assigned for code review.', 'f');
INSERT INTO "public"."TicketStatus" VALUES ('2', 'Complete', 'The ticket is complete', 'f');
INSERT INTO "public"."TicketStatus" VALUES ('4', 'Completed', 'This status is complete', 'f');
INSERT INTO "public"."TicketStatus" VALUES ('5', 'Closed', 'The ticket is no longer open.', 'f');
INSERT INTO "public"."TicketStatus" VALUES ('6', 'Open', 'The ticket is openss', 'f');
INSERT INTO "public"."TicketStatus" VALUES ('7', 'Super Closed', 'Very closed', 'f');

-- ----------------------------
-- Table structure for "public"."TicketType"
-- ----------------------------
DROP TABLE "public"."TicketType";
CREATE TABLE "public"."TicketType" (
"Id" int4 DEFAULT nextval('"TicketType_Id_seq"'::regclass) NOT NULL,
"Name" varchar(50) NOT NULL,
"Description" varchar(250) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of TicketType
-- ----------------------------
INSERT INTO "public"."TicketType" VALUES ('1', 'Task', 'adadasd');
INSERT INTO "public"."TicketType" VALUES ('2', 'Bug', 'This ticket represents a bug with the application.');
INSERT INTO "public"."TicketType" VALUES ('3', 'Improvement', 'This ticket represents an improvement that needs to happen with the application.');
INSERT INTO "public"."TicketType" VALUES ('4', 'Code Review', 'saaa');
INSERT INTO "public"."TicketType" VALUES ('5', 'Database Change Request', 'Change');

-- ----------------------------
-- Table structure for "public"."User"
-- ----------------------------
DROP TABLE "public"."User";
CREATE TABLE "public"."User" (
"Id" int4 DEFAULT nextval('"User_Id_seq"'::regclass) NOT NULL,
"Email" varchar(100) NOT NULL,
"Password" varchar(200) NOT NULL,
"Salt" char(10) NOT NULL,
"Created" timestamp(6) NOT NULL,
"LastLogin" timestamp(6),
"TotalComments" int4 NOT NULL,
"FailedPasswordAttemptCount" int4 NOT NULL,
"RoleId" int4 NOT NULL,
"LastFailedLoginAttempt" timestamp(6),
"FirstName" varchar(50) NOT NULL,
"LastName" varchar(50) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO "public"."User" VALUES ('2', 'justinsss@gmail.com', 'justin', 'jS-5{6GdxH', '2010-01-01 00:00:00', '2010-01-01 00:00:00', '0', '6', '2', '2010-10-24 22:27:16', 'Another', 'Lady');
INSERT INTO "public"."User" VALUES ('6', '12554@gmail.com', '5X4YGcMgV6Ldms6ccVeT2E+tIIhyoGirrq/L5GYjbOnYg3CZZZlTE6qWg4wgO9Zv9p//oywIwBAXQk/V+2VeCEYrcTRtNj1YUGQ=', 'F+q4m6=XPd', '2010-08-16 23:02:22', '2010-08-16 23:02:22', '0', '0', '2', '2010-08-16 23:02:22', 'Dave', 'Guy');
INSERT INTO "public"."User" VALUES ('7', 'sara@gmail.com', 'Y0YwrnErqNcR8qjoI5IQnMSYrqucFZB4gr6f9xsK5LjgqfPxyjw+plut9ioafGkeLnKaCbyVcd5GkmjgiZQ8mWRGXzhYJjdxYk4=', 'dF_8X&7qbN', '2010-10-24 17:07:42', '2010-10-24 22:29:34', '0', '0', '2', '2010-10-24 17:07:42', 'Sara', 'Girl');
INSERT INTO "public"."User" VALUES ('8', 'bob@bob.ca', 'qv3oRVFYxGtA4LHhudcvmje3lmxpazdt9PWmkk/b3DD9rl3/TJZIerHL56Vjw4tc29VJc/Nhify0Av9MbQmkCDlaZyokYzZCeTc=', '9Zg*$c6By7', '2010-10-24 19:36:25', '2010-10-24 19:36:25', '0', '0', '2', '2010-10-24 19:36:25', 'Bob', 'Guy');
INSERT INTO "public"."User" VALUES ('9', '1111', 'reTLt4iVq0sg1ubXDkjILN0vcRHzTueg8zRevyOzVmQMeQmkpUPpxoCT293n1ILPc1tifYRubMapS9sX+FW09DVwP1JZMmF9IXc=', '5p?RY2a}!w', '2010-10-24 19:52:25', null, '0', '0', '2', null, 'Harry', 'Guy');
INSERT INTO "public"."User" VALUES ('10', 'ghj@gmail.ca', 'oQpPsJ1loxODsdgIW1lhEjxoPDE4npoPEiZe7BSPYq2JdVg4K4aalKFdd3SqDgMMrmzXm3rKXEmCdLpvqGHx4DdjKlF0RTJ7RyE=', '7c*QtE2{G!', '2010-10-24 20:04:37', null, '0', '0', '2', null, 'Naked', 'Girl');
INSERT INTO "public"."User" VALUES ('12', 'justin', 'w3ek2Rw5Jaj7vHr3ywjT4IEIbg8wiY2zMy9VpKmp+hJKPx55dMMG9go2NwcenlpttP7G2WO1fpTi4Cas67ykdDhrJVhRITV6NGk=', '8k%XQ!5z4i', '2010-10-24 22:30:58', '2010-11-20 15:10:48', '0', '7', '2', '2010-11-19 23:41:18', 'Buzz', 'Killington');
INSERT INTO "public"."User" VALUES ('13', 'justin.arvay@gmail.com', 'uO3Rgc3JAoHOcyDfAvVn2mgp9h9VMwvXGUOuHZ0FIfS7fjH6w3rssxzFeGKGKHfRg6E7OrVAfUWB8QKywsf2K3IqNUY3RV9reCU=', 'r*5F7E_kx%', '2010-11-09 20:14:15', '2011-12-03 17:34:01', '0', '39', '2', '2011-12-03 17:33:52', 'Justin', 'Arvay');
INSERT INTO "public"."User" VALUES ('14', 'some.guy@gmail.com', 'p/M1qrfBsVxKdIsEZlEYlHAeNOShvdXbqCpohqMhLOxKiKr6K4MqH37aY0H7Xcfca2SHdqsz1jLs4rll4OFLVksqcDZrRDQmL20=', 'K*p6kD4&/m', '2010-11-19 00:34:11', '2010-11-21 16:49:18', '0', '0', '2', null, 'Some', 'Guy');
INSERT INTO "public"."User" VALUES ('15', 'some.guy2@gmail.com', '12345678', 'e*6P-4Qca{', '2010-11-19 00:38:44', null, '0', '0', '2', null, 'some', 'guy2');
INSERT INTO "public"."User" VALUES ('17', 'sara.romano@gmail.com', 'C6RFSkOi/L7X5PP0tHIHuMN9yaTOES3Y0FVOdTF66dBpTgaLaEhSLtn+HenSfXX5MP/26lYr4Mdu5OdTo3Kp5ThUbV9mJEc1JTM=', '8Tm_f$G5%3', '2010-11-21 17:35:10', null, '0', '0', '2', null, 'Sara', 'Romano');

-- ----------------------------
-- Table structure for "public"."WorkLog"
-- ----------------------------
DROP TABLE "public"."WorkLog";
CREATE TABLE "public"."WorkLog" (
"Id" int4 DEFAULT nextval('"WorkLog_Id_seq"'::regclass) NOT NULL,
"DoneBy" int4 NOT NULL,
"Description" text NOT NULL,
"Created" timestamp(6) NOT NULL,
"TimeSpent" int4 NOT NULL,
"TicketId" int4 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of WorkLog
-- ----------------------------

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------
ALTER SEQUENCE "public"."ColorPalette_Id_seq" OWNED BY "ColorPalette"."Id";
ALTER SEQUENCE "public"."Comment_Id_seq" OWNED BY "Comment"."Id";
ALTER SEQUENCE "public"."Component_Id_seq" OWNED BY "Component"."Id";
ALTER SEQUENCE "public"."ComponentTicket_Id_seq" OWNED BY "ComponentTicket"."Id";
ALTER SEQUENCE "public"."File_Id_seq" OWNED BY "File"."Id";
ALTER SEQUENCE "public"."Project_Id_seq" OWNED BY "Project"."Id";
ALTER SEQUENCE "public"."ProjectVersion_Id_seq" OWNED BY "ProjectVersion"."Id";
ALTER SEQUENCE "public"."Property_Id_seq" OWNED BY "Property"."Id";
ALTER SEQUENCE "public"."Role_Id_seq" OWNED BY "Role"."Id";
ALTER SEQUENCE "public"."Ticket_Id_seq" OWNED BY "Ticket"."Id";
ALTER SEQUENCE "public"."TicketFixedOnVersion_Id_seq" OWNED BY "TicketFixedOnVersion"."Id";
ALTER SEQUENCE "public"."TicketFoundOnVersion_Id_seq" OWNED BY "TicketFoundOnVersion"."Id";
ALTER SEQUENCE "public"."TicketPriority_Id_seq" OWNED BY "TicketPriority"."Id";
ALTER SEQUENCE "public"."TicketResolution_Id_seq" OWNED BY "TicketResolution"."Id";
ALTER SEQUENCE "public"."TicketStatus_Id_seq" OWNED BY "TicketStatus"."Id";
ALTER SEQUENCE "public"."TicketType_Id_seq" OWNED BY "TicketType"."Id";
ALTER SEQUENCE "public"."User_Id_seq" OWNED BY "User"."Id";
ALTER SEQUENCE "public"."WorkLog_Id_seq" OWNED BY "WorkLog"."Id";

-- ----------------------------
-- Primary Key structure for table "public"."ColorPalette"
-- ----------------------------
ALTER TABLE "public"."ColorPalette" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."Comment"
-- ----------------------------
ALTER TABLE "public"."Comment" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."Component"
-- ----------------------------
ALTER TABLE "public"."Component" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."ComponentTicket"
-- ----------------------------
ALTER TABLE "public"."ComponentTicket" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."File"
-- ----------------------------
ALTER TABLE "public"."File" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table Project
-- ----------------------------
CREATE INDEX "Project_Unique_KeyName" ON "public"."Project" USING btree ("KeyName");
CREATE INDEX "Project_Unique_Name" ON "public"."Project" USING btree ("Name");

-- ----------------------------
-- Primary Key structure for table "public"."Project"
-- ----------------------------
ALTER TABLE "public"."Project" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."ProjectVersion"
-- ----------------------------
ALTER TABLE "public"."ProjectVersion" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table Property
-- ----------------------------
CREATE INDEX "Property_Unique_Identifier" ON "public"."Property" USING btree ("Identifier");

-- ----------------------------
-- Primary Key structure for table "public"."Property"
-- ----------------------------
ALTER TABLE "public"."Property" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."Role"
-- ----------------------------
ALTER TABLE "public"."Role" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."Ticket"
-- ----------------------------
ALTER TABLE "public"."Ticket" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."TicketFixedOnVersion"
-- ----------------------------
ALTER TABLE "public"."TicketFixedOnVersion" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."TicketFoundOnVersion"
-- ----------------------------
ALTER TABLE "public"."TicketFoundOnVersion" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table TicketPriority
-- ----------------------------
CREATE INDEX "IX_TicketPriority_UniqueNAme" ON "public"."TicketPriority" USING btree ("Name");

-- ----------------------------
-- Primary Key structure for table "public"."TicketPriority"
-- ----------------------------
ALTER TABLE "public"."TicketPriority" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table TicketResolution
-- ----------------------------
CREATE INDEX "IX_TicketResolution_UniqueName" ON "public"."TicketResolution" USING btree ("Name");

-- ----------------------------
-- Primary Key structure for table "public"."TicketResolution"
-- ----------------------------
ALTER TABLE "public"."TicketResolution" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."TicketStatus"
-- ----------------------------
ALTER TABLE "public"."TicketStatus" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table TicketType
-- ----------------------------
CREATE INDEX "IX_TicketType_UniqueName" ON "public"."TicketType" USING btree ("Name");

-- ----------------------------
-- Primary Key structure for table "public"."TicketType"
-- ----------------------------
ALTER TABLE "public"."TicketType" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."User"
-- ----------------------------
ALTER TABLE "public"."User" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table "public"."WorkLog"
-- ----------------------------
ALTER TABLE "public"."WorkLog" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Foreign Key structure for table "public"."Comment"
-- ----------------------------
ALTER TABLE "public"."Comment" ADD FOREIGN KEY ("UserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Comment" ADD FOREIGN KEY ("TicketId") REFERENCES "public"."Ticket" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."Component"
-- ----------------------------
ALTER TABLE "public"."Component" ADD FOREIGN KEY ("ProjectId") REFERENCES "public"."Project" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Component" ADD FOREIGN KEY ("TicketId") REFERENCES "public"."Ticket" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."ComponentTicket"
-- ----------------------------
ALTER TABLE "public"."ComponentTicket" ADD FOREIGN KEY ("TicketId") REFERENCES "public"."Ticket" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."ComponentTicket" ADD FOREIGN KEY ("ComponentId") REFERENCES "public"."Component" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."Project"
-- ----------------------------
ALTER TABLE "public"."Project" ADD FOREIGN KEY ("AvatarId") REFERENCES "public"."File" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Project" ADD FOREIGN KEY ("Lead") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Project" ADD FOREIGN KEY ("ColorPaletteId") REFERENCES "public"."ColorPalette" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."ProjectVersion"
-- ----------------------------
ALTER TABLE "public"."ProjectVersion" ADD FOREIGN KEY ("ProjectId") REFERENCES "public"."Project" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."Ticket"
-- ----------------------------
ALTER TABLE "public"."Ticket" ADD FOREIGN KEY ("StatusId") REFERENCES "public"."TicketStatus" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Ticket" ADD FOREIGN KEY ("PriorityId") REFERENCES "public"."TicketPriority" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Ticket" ADD FOREIGN KEY ("ResolutionId") REFERENCES "public"."TicketResolution" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Ticket" ADD FOREIGN KEY ("TypeId") REFERENCES "public"."TicketType" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Ticket" ADD FOREIGN KEY ("CreatedByUserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Ticket" ADD FOREIGN KEY ("AssignedByUserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."Ticket" ADD FOREIGN KEY ("AssignedToUserId") REFERENCES "public"."User" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."TicketFixedOnVersion"
-- ----------------------------
ALTER TABLE "public"."TicketFixedOnVersion" ADD FOREIGN KEY ("TicketId") REFERENCES "public"."Ticket" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."TicketFixedOnVersion" ADD FOREIGN KEY ("VersionId") REFERENCES "public"."ProjectVersion" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."TicketFoundOnVersion"
-- ----------------------------
ALTER TABLE "public"."TicketFoundOnVersion" ADD FOREIGN KEY ("VersionId") REFERENCES "public"."ProjectVersion" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."TicketFoundOnVersion" ADD FOREIGN KEY ("TicketId") REFERENCES "public"."Ticket" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."User"
-- ----------------------------
ALTER TABLE "public"."User" ADD FOREIGN KEY ("RoleId") REFERENCES "public"."Role" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."WorkLog"
-- ----------------------------
ALTER TABLE "public"."WorkLog" ADD FOREIGN KEY ("TicketId") REFERENCES "public"."Ticket" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
