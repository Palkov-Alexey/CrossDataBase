pragma auto_vacuum = 1;

create table process_history
(
    id         integer not null,
    process_id integer null,
    status     integer not null,
    data       text    null,
    primary key (id autoincrement)
);

create table process
(
    id   integer not null,
    name text    null,
    primary key (id autoincrement)
);

create table node
(
    id         integer not null,
    process_id integer null,
    type       integer not null,
    pos_x      integer not null,
    pos_y      integer not null,
    data       text    not null,
    primary key (id autoincrement)
);

create table connector
(
    id         integer not null,
    process_id integer null,
    from_node  integer not null,
    [from]     text    not null,
    to_node    integer not null,
    [to]       text    not null,
    primary key (id autoincrement)
);