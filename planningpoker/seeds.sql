PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory VALUES('20200608202359_InitialMigration','3.1.3');
CREATE TABLE IF NOT EXISTS "Projects" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Projects" PRIMARY KEY,
    "Name" TEXT NULL,
    "Description" TEXT NULL
);
INSERT INTO Projects VALUES('9ebf3fe3-f318-4d5f-97d2-02835079fa6b','Jean''s Project','This project belong to Jean, you can contact him for more information.');
INSERT INTO Projects VALUES('225ccf35-d0a5-4d39-ae94-70fced7d69f5','Adrian''s Project','This project belong to Adrian, you can contact him for more information.');
INSERT INTO Projects VALUES('2f32f488-1e05-4e06-a4aa-7f0f06c22e19','Burak''s Project','This project belong to Burak, you can contact him for more information.');
INSERT INTO Projects VALUES('24a50d65-6699-483d-a29d-372802afc43e','Kryztszof''s Project','This project belong to Kryztszof, you can contact him for more information.');
CREATE TABLE IF NOT EXISTS "Users" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY,
    "Username" TEXT NULL,
	
	"PasswordHash" TEXT NULL,
);
INSERT INTO Users VALUES('4c093cf3-2090-4f29-8ce0-2b1d961f455c','jean','cvZbpe51dWr5RXBhCg6hdiM6iYJd199TODEsLaClZbE=');
INSERT INTO Users VALUES('bec2e309-dc12-447f-afd6-ee19f55ffcba','adrian','oUgZw25sU4nNxzLIVVmftPuI5vWqjdQQQYXah+C9984=');
INSERT INTO Users VALUES('de661c93-5ce9-48f3-93d6-0744036443ed','burak','TcmQq5575FX9/D/NsiAhxn48rv1xWr+TD5bJpti+L6Y=');
INSERT INTO Users VALUES('abdbcada-75da-446a-a8d0-a0169d16ce90','krzysztof','9G/dxYndwRR+Zq7Zn/Fby8nuoaeR4gHj1qRWj7WK9fo=');
CREATE TABLE IF NOT EXISTS "ProjectPermissions" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_ProjectPermissions" PRIMARY KEY,
    "UserId" TEXT NULL,
    "ProjectId" TEXT NULL,
    "PermissionType" INTEGER NOT NULL,
    CONSTRAINT "FK_ProjectPermissions_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_ProjectPermissions_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);
INSERT INTO ProjectPermissions VALUES('39b37995-bc0a-43e8-a79f-aeb7ea270b84','4c093cf3-2090-4f29-8ce0-2b1d961f455c','9ebf3fe3-f318-4d5f-97d2-02835079fa6b',0);
INSERT INTO ProjectPermissions VALUES('df72e757-0ea3-4836-93cb-f9a74646d005','bec2e309-dc12-447f-afd6-ee19f55ffcba','225ccf35-d0a5-4d39-ae94-70fced7d69f5',0);
INSERT INTO ProjectPermissions VALUES('75805d67-7e1b-4813-bb11-f27672042aad','de661c93-5ce9-48f3-93d6-0744036443ed','2f32f488-1e05-4e06-a4aa-7f0f06c22e19',0);
INSERT INTO ProjectPermissions VALUES('74f15185-2111-4868-b6f2-94cbf840e57e','abdbcada-75da-446a-a8d0-a0169d16ce90','24a50d65-6699-483d-a29d-372802afc43e',0);
INSERT INTO ProjectPermissions VALUES('d7d19ca5-326e-4e31-8cf0-d57e9dcc875f','4c093cf3-2090-4f29-8ce0-2b1d961f455c','225ccf35-d0a5-4d39-ae94-70fced7d69f5',1);
INSERT INTO ProjectPermissions VALUES('dd6fc041-b6cc-40fe-9329-fd1aae1cc96c','bec2e309-dc12-447f-afd6-ee19f55ffcba','9ebf3fe3-f318-4d5f-97d2-02835079fa6b',1);
INSERT INTO ProjectPermissions VALUES('6d0f2271-e681-411f-874e-f28462a1bb25','de661c93-5ce9-48f3-93d6-0744036443ed','9ebf3fe3-f318-4d5f-97d2-02835079fa6b',1);
INSERT INTO ProjectPermissions VALUES('23ac0345-418d-4d79-8711-3a937d67917c','abdbcada-75da-446a-a8d0-a0169d16ce90','9ebf3fe3-f318-4d5f-97d2-02835079fa6b',1);
CREATE TABLE IF NOT EXISTS "Tasks" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Tasks" PRIMARY KEY,
    "Name" TEXT NULL,
    "Description" TEXT NULL,
    "Estimation" INTEGER NOT NULL,
    "ProjectId" TEXT NULL,
    "AssigneeId" TEXT NULL,
    CONSTRAINT "FK_Tasks_Users_AssigneeId" FOREIGN KEY ("AssigneeId") REFERENCES "Users" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Tasks_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("Id") ON DELETE RESTRICT
);
INSERT INTO Tasks VALUES('aa59c945-8ded-48ca-b6cf-b04801f02176','Task 1','This is a description of task 1',34,'9ebf3fe3-f318-4d5f-97d2-02835079fa6b','4c093cf3-2090-4f29-8ce0-2b1d961f455c');
INSERT INTO Tasks VALUES('2d6a7986-5577-4203-bc4f-070b7231c2d0','Task 2','This is a description of task 2',0,'9ebf3fe3-f318-4d5f-97d2-02835079fa6b','4c093cf3-2090-4f29-8ce0-2b1d961f455c');
CREATE TABLE IF NOT EXISTS "Comments" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Comments" PRIMARY KEY,
    "Created" TEXT NOT NULL,
    "TaskId" TEXT NULL,
    "UserId" TEXT NULL,
    "Text" TEXT NULL,
    CONSTRAINT "FK_Comments_Tasks_TaskId" FOREIGN KEY ("TaskId") REFERENCES "Tasks" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Comments_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);
INSERT INTO Comments VALUES('9351dcf2-120f-4ac2-bb6b-3d8c53f396a0','2020-06-08 22:28:09.5476752+02:00','aa59c945-8ded-48ca-b6cf-b04801f02176','4c093cf3-2090-4f29-8ce0-2b1d961f455c','please vote with more points that you think it should');
INSERT INTO Comments VALUES('4f802b66-9d2a-47f2-92a6-918e53a9f202','2020-06-08 22:44:01.3164536+02:00','aa59c945-8ded-48ca-b6cf-b04801f02176','de661c93-5ce9-48f3-93d6-0744036443ed','done');
CREATE TABLE IF NOT EXISTS "TaskEstimations" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_TaskEstimations" PRIMARY KEY,
    "Updated" TEXT NOT NULL,
    "Estimation" INTEGER NOT NULL,
    "UserId" TEXT NULL,
    "TaskId" TEXT NULL,
    CONSTRAINT "FK_TaskEstimations_Tasks_TaskId" FOREIGN KEY ("TaskId") REFERENCES "Tasks" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_TaskEstimations_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);
INSERT INTO TaskEstimations VALUES('6a7d9c4e-ffef-4c62-942e-5dc2f0262969','2020-06-08 22:43:38.2904179+02:00',34,'bec2e309-dc12-447f-afd6-ee19f55ffcba','aa59c945-8ded-48ca-b6cf-b04801f02176');
INSERT INTO TaskEstimations VALUES('e7f1d591-1fe7-4173-b2b8-f80fd3e8ee1d','2020-06-08 22:43:58.0922888+02:00',34,'de661c93-5ce9-48f3-93d6-0744036443ed','aa59c945-8ded-48ca-b6cf-b04801f02176');
INSERT INTO TaskEstimations VALUES('dbbbecd4-c773-41ac-a3e1-a3d5037ec2d1','2020-06-08 22:44:16.9546043+02:00',21,'abdbcada-75da-446a-a8d0-a0169d16ce90','aa59c945-8ded-48ca-b6cf-b04801f02176');
INSERT INTO TaskEstimations VALUES('d5bc99ed-3bc9-45d6-bba6-80ed0cafba84','2020-06-08 22:45:45.8480712+02:00',123456,'4c093cf3-2090-4f29-8ce0-2b1d961f455c','aa59c945-8ded-48ca-b6cf-b04801f02176');
CREATE INDEX "IX_Comments_TaskId" ON "Comments" ("TaskId");
CREATE INDEX "IX_Comments_UserId" ON "Comments" ("UserId");
CREATE INDEX "IX_ProjectPermissions_ProjectId" ON "ProjectPermissions" ("ProjectId");
CREATE INDEX "IX_ProjectPermissions_UserId" ON "ProjectPermissions" ("UserId");
CREATE INDEX "IX_TaskEstimations_TaskId" ON "TaskEstimations" ("TaskId");
CREATE INDEX "IX_TaskEstimations_UserId" ON "TaskEstimations" ("UserId");
CREATE INDEX "IX_Tasks_AssigneeId" ON "Tasks" ("AssigneeId");
CREATE INDEX "IX_Tasks_ProjectId" ON "Tasks" ("ProjectId");
COMMIT;
