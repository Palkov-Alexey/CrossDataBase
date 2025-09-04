update connector
set from_node = @FromNode,
    [from] = @From,
    to_node = @ToNode,
    [to] = @To
where id = @Id
  and process_id = @ProcessId;