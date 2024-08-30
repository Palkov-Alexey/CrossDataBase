PRAGMA main.auto_vacuum = 1;

CREATE TABLE "process" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE INDEX "ix__process__name" ON "process" (
	"name"
);

CREATE TABLE "process_node" (
	"id"	INTEGER NOT NULL,
	"process_id"	INTEGER NOT NULL,
	"type"	INTEGER NOT NULL,
	"data"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE TABLE "process_node_connection" (
	"id"	INTEGER NOT NULL,
	"from_node_id"	INTEGER NOT NULL,
	"from_node_point"	TEXT NOT NULL,
	"to_node_id"	INTEGER NOT NULL,
	"to_node_point"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);