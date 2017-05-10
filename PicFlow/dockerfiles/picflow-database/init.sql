
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

                                                                                                                                         
INSERT INTO mt_doc_user (id, data, mt_last_modified, mt_version, mt_dotnet_type) VALUES ('7b5e9972-4f2c-4a36-9929-c37f66846a45', 
'{"Id": "7b5e9972-4f2c-4a36-9929-c37f66846a45", "LastName": "Maier", "UserName": "jmaier", "FirstName": "Jürgen", "PasswordHash": "tPOxK2RU/2OsmXbei9RZFPaROVY="}',
 '2017-05-10 18:35:57.767141+00', '28136fa7-0e42-4fe8-81ce-ef4a4235d143', 'FP.MsRMQ.PicFlow.Contracts.Dbo.User');      

INSERT INTO mt_doc_user (id, data, mt_last_modified, mt_version, mt_dotnet_type) VALUES ('b44af49a-b1e9-471d-8f40-22bde0f27440',
'{"Id": "b44af49a-b1e9-471d-8f40-22bde0f27440", "LastName": "Kaufmann", "UserName": "wkaufmann", "FirstName": "Wolfgang", "PasswordHash": "tPOxK2RU/2OsmXbei9RZFPaROVY="}',
 '2017-05-10 18:37:41.280775+00', '2f136fa7-5f4b-4cb8-b5ca-085390e944ce', 'FP.MsRMQ.PicFlow.Contracts.Dbo.User'
);                                                                                                                                       
INSERT INTO mt_doc_user (id, data, mt_last_modified, mt_version, mt_dotnet_type) VALUES ('e4edb4db-e918-47f2-afe6-6e41eff35ae0',
'{"Id": "e4edb4db-e918-47f2-afe6-6e41eff35ae0", "LastName": "Mustermann", "UserName": "mmustermann", "FirstName": "Max", "PasswordHash": "tPOxK2RU/2OsmXbei9RZFPaROVY="}',
 '2017-05-10 18:41:19.653531+00', '3f136fa7-474b-4698-8afd-46ab459dc0c1', 'FP.MsRMQ.PicFlow.Contracts.Dbo.User'
 );
