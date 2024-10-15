PRAGMA main.auto_vacuum = 1;

CREATE TABLE "process" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT,
	"data"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE INDEX "ix__process__name" ON "process" (
	"name"
);