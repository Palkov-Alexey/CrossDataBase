select id         as Id,
       process_id as ProcessId,
       type       as Type,
       pos_x      as PosX,
       pos_y      as PosY,
       fields     as Fields,
       data       as Data
from node
where id = @Id
  and process_id = @ProcessId;