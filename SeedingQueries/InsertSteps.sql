Insert into step (TestId, StepNr, Label, Log, Description, Weight) values
(1,1,'Open the website with URL just /','','',1),
(2,1,'Try logging in as admin','','Use admin-admin',1),
(2,2,'Try logging in as tester','','Use tester-tester',1),
(2,3,'Try logging in as editor','','Use editor-editor',1),
(3,1,'Try register with correct data','','',1),
(3,2,'Try register with incorrect username length','','',2),
(3,3,'Try register with incorrect username characters','','',1),
(3,4,'Try register with incorrect password length','','',2),
(3,5,'Try register with insufficient password security level','','',2),
(4,1,'Verify that when logged in, the users page displays information only about the logged in user','','',1),
(5,1,'Verify that when NOT logged in, the users page redirects to log in','','',1),
(6,1,'Generating report shows logged in users data only','','',3),
(6,2,'Generating report as admin shows selected users data','','',4)