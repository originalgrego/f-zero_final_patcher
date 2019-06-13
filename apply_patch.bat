del "F-Zero_Final.sfc"

copy "F-Zero.sfc" "F-Zero_Final.sfc"

xkas.exe merge_expand.asm "F-Zero_Final.sfc"

liteips.exe F-Zero_Final.ips F-Zero_Final.sfc

del "F-Zero.sfc"

del "F-Zero_GP2.sfc"