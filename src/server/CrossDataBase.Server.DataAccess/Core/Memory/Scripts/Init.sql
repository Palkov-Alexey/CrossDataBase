CREATE TABLE "process_history" (
    "id"	INTEGER,
    "process_id"	TEXT NOT NULL,
    "status"	INTEGER NOT NULL,
    "node_id"	TEXT NOT NULL,
    "data"	TEXT NOT NULL,
    PRIMARY KEY("id")
);

CREATE INDEX "ix__process_history__process_id" ON "process_history" (
    "process_id"
);