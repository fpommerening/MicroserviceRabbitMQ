
CREATE TABLE "mt_doc_user"
(
    id uuid NOT NULL,
    data jsonb NOT NULL,
    mt_last_modified timestamp with time zone DEFAULT transaction_timestamp(),
    mt_version uuid NOT NULL DEFAULT (md5(((random())::text || (clock_timestamp())::text)))::uuid,
    mt_dotnet_type character varying,
    CONSTRAINT pk_mt_doc_user PRIMARY KEY (id)
);


COMMENT ON TABLE "mt_doc_user"
    IS 'origin:Marten.IDocumentStore, Marten, Version=1.1.0.762, Culture=neutral, PublicKeyToken=null';

INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('3e149ba6-6e45-4057-8c9e-17be9f426438',
'{"UserName": "jmeier", "LastName": "Meier", "PasswordHash": "YBCgtof2PkRxL//i4H/0K9zmpH8=", "Id": "3e149ba6-6e45-4057-8c9e-17be9f426334", "FirstName": "Jürgen"}',
 '2016-10-10 19:39:16.424395+00', '3e149ba6-a945-4e98-93b6-213e746bf64f', 'FP.MsRMQ.PicFlow.Contracts.Dbo.User');
	
INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('47149ba6-1b42-4a27-8e8d-6ea09e88d43f',
'{"UserName": "wkaufmann", "LastName": "Kaufmann", "PasswordHash": "YBCgtof2PkRxL//i4H/0K9zmpH8=", "Id" : "47149ba6-1b42-4a27-8e8d-6ea09e88d43f", "FirstName": "Wolfgang"}',
 '2016-10-10 19:41:16.480185+00', '47149ba6-5a42-4eab-b96a-76de6cac7c3a', 'FP.MsRMQ.PicFlow.Contracts.Dbo.User');

INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('4c149ba6-974e-4996-8fe3-c0a849f53e09',
'{"UserName": "smueller", "LastName": "Müller", "PasswordHash": "YBCgtof2PkRxL//i4H/0K9zmpH8=", "Id" : "4c149ba6-974e-4996-8fe3-c0a849f53e09", "FirstName": "Sabine"}',
 '2016-10-10 19:42:35.391597+00', '4c149ba6-d34e-430d-9b2a-4d7703e5208d', 'FP.MsRMQ.PicFlow.Contracts.Dbo.User');
 
 INSERT INTO "mt_doc_user"(id, data, mt_last_modified, mt_version, mt_dotnet_type)
	values ('4f149ba6-a147-4191-ae23-f67614dd50b1',
'{"UserName": "klehmann", "LastName": "Lehmann", "PasswordHash": "YBCgtof2PkRxL//i4H/0K9zmpH8=", "Id" : "4f149ba6-a147-4191-ae23-f67614dd50b1", "FirstName": "Kevin"}',
 '2016-10-10 19:43:10.415857+00', '4f149ba6-df47-477a-9719-30e0aab49b81', 'FP.MsRMQ.PicFlow.Contracts.Dbo.User');
	