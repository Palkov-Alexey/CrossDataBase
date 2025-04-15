select id as Id,
       process_id as ProcessId,
       from_node as FromNode,
       [from] as [From],
       to_node as ToNode,
       [to] as [To]
from connector
where process_id = @ProcessId;