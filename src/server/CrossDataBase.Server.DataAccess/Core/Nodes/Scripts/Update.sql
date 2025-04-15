update node
set type   = @Type,
    pos_x  = @PosX,
    pos_y  = @PosY,
    fields = @Fields,
    data   = @Data
where id = @Id
  and process_id = @ProcessId;