-- 빈 공간 : .
-- 플레이어 : p
-- 벽 : w
-- 목적지 : g
-- 상자 : b
-- 몬스터 : m
-- 가시 : s
-- 꺼진가시 : v
-- 켜진가시 : A

Map_C = {
    TurnCount = 53,
    Width = 13,
    Height = 15,
    Puzzle =
    "00000wwww0000" ..
    "000ww.sbsww00" ..
    "00wbsbs.s.sw0" ..
    "0ws..bsbs.s.w" ..
    "0ws.sbwwsbs.w" ..
    "w.sbsw00wb.pw" ..
    "wbs.w0000wwww" ..
    "w..bw00000000" ..
    "w.s.w0000wwww" ..
    "w.sb.w00w.sgw" ..
    "0ws.sbwwsbs.w" ..
    "0wsbs.sbs..bw" ..
    "00wbsb..sbsw0" ..
    "000wwbsbsww00" ..
    "00000wwww0000"
}

Map_temp = {
    TurnCount = 3,
    Width = 3,
    Height = 5,
    Puzzle =
    "www" ..
    "wsw" ..
    "wpw" ..
    "w.w" ..
    "www"
}