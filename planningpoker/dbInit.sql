INSERT INTO Users (Id, Username) VALUES ('450080c4-9ce3-4ced-aa63-9b1a7fd35d00', 'jess');

INSERT INTO Projects (Id, Name, Description) VALUES ('1b51b9fa-3ee2-4af4-98c0-29a2cfbe6dfb', 'newProject', null);

INSERT INTO ProjectPermissions (Id, UserId, ProjectId, PermissionType) VALUES ('41324f45-6e96-45ee-a187-402bedec86c2', '450080c4-9ce3-4ced-aa63-9b1a7fd35d00', '1b51b9fa-3ee2-4af4-98c0-29a2cfbe6dfb', 1);

INSERT INTO Tasks (Id, Name, Description, Estimation, ProjectId, AssigneeId) VALUES ('a9b3bff8-d5ab-4325-8f83-ef7f10ff1ba5', 'Task 1', 'Dance bitch', 0, '1b51b9fa-3ee2-4af4-98c0-29a2cfbe6dfb', null);
INSERT INTO Tasks (Id, Name, Description, Estimation, ProjectId, AssigneeId) VALUES ('d54dbeb5-db7b-4d39-8da3-59b0f19780da', 'Task 2', 'Dance harder!', 0, '1b51b9fa-3ee2-4af4-98c0-29a2cfbe6dfb', null);

INSERT INTO Comments (Id, Created, TaskId, UserId, Text) VALUES ('2d7865de-f04c-4ec9-ac98-b6ca8850cd6e', '2020-05-17 10:29:32.5619681', 'a9b3bff8-d5ab-4325-8f83-ef7f10ff1ba5', '450080c4-9ce3-4ced-aa63-9b1a7fd35d00', 'lame task');
INSERT INTO Comments (Id, Created, TaskId, UserId, Text) VALUES ('58fb8b08-6e12-4348-8436-e34bc91ab5ea', '2020-05-17 10:31:44.0483779', 'a9b3bff8-d5ab-4325-8f83-ef7f10ff1ba5', '450080c4-9ce3-4ced-aa63-9b1a7fd35d00', 'lame task');
INSERT INTO Comments (Id, Created, TaskId, UserId, Text) VALUES ('7fc03ee1-282b-4f9b-95f1-487daf1a5fb2', '2020-05-17 10:31:55.4595634', 'a9b3bff8-d5ab-4325-8f83-ef7f10ff1ba5', '450080c4-9ce3-4ced-aa63-9b1a7fd35d00', 'lame task');
INSERT INTO Comments (Id, Created, TaskId, UserId, Text) VALUES ('727a0ee3-7ea8-4b83-bb96-ed4be4d229a0', '2020-05-17 10:32:05.2622748', 'a9b3bff8-d5ab-4325-8f83-ef7f10ff1ba5', '450080c4-9ce3-4ced-aa63-9b1a7fd35d00', 'lame task');
INSERT INTO Comments (Id, Created, TaskId, UserId, Text) VALUES ('c6b3c96a-d201-48ee-a0eb-ccc6083c7d22', '2020-05-17 10:32:17.9387962', 'a9b3bff8-d5ab-4325-8f83-ef7f10ff1ba5', '450080c4-9ce3-4ced-aa63-9b1a7fd35d00', 'lame task');

INSERT INTO TaskEstimations (Id, Updated, Estimation, UserId, TaskId) VALUES ('7346992d-7fd6-46f8-b495-adc8caee9bff', '2020-05-17 11:20:49.8240707+02:00', 5, '450080c4-9ce3-4ced-aa63-9b1a7fd35d00', 'a9b3bff8-d5ab-4325-8f83-ef7f10ff1ba5');