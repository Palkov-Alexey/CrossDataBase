CREATE TABLE "process_history" (
    "id"	INTEGER NOT NULL,
    "process_id"	TEXT NOT NULL,
    "status"	INTEGER NOT NULL,
    "data"	TEXT NOT NULL,
    PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE INDEX "ix__process_history__process_id" ON "process_history" (
    "process_id"
);