-- 빈 공간 : 0
-- 내부 빈 공간 : .
-- 플레이어 : p
-- 벽 : w
-- 목적지 : g
-- 열쇠 : k
-- 상자 : b
-- 가시 위 상자 : n
-- 잠긴상자 : l
-- 몬스터 : m
-- 가시 : s
-- 꺼진가시 : v
-- 켜진가시 : A
-- 특수가시 : ({[<>]})
-- 부서지는 상자 : 1 ~ 9
-- 포탈 : o

-- 사용된 기믹 순서
-- 상자, 몬스터, 가시, 열쇠, 한턴가시, 부서지는상자, 스페셜가시, 포탈


SpecialPattern = {
    Pattern1 = {true, false, false, false},
    Pattern2 = {true, false, false, false},
    Pattern3 = {true, false, false, false},
    Pattern4 = {true, false, false, false}
}

JS_1 = {
    TurnCount = 10,
    Width = 7,
    Height = 6,
    Puzzle =
    "0ww0ww0" ..
    "w.pwg.w" ..
    "w.b.b.w" ..
    "w.b.b.w" ..
    "0w.b.w0" ..
    "00www00" ,

    Obstacles = {true, false, false, false, false, false, false, false}
}

JS_2 = {
    TurnCount = 20,
    Width = 9,
    Height = 8,
    Puzzle =
    "0ww000ww0" ..
    "wp.w0w.gw" ..
    "w..bw...w" ..
    "w.b.b.b.w" ..
    "w...bb..w" ..
    "0w..b.bw0" ..
    "00wb..w00" ..
    "000www000",

    Obstacles = {true, false, false, false, false, false, false, false}
}

PY_1 = {
    TurnCount = 17,
    Width = 7,
    Height = 7,
    Puzzle =
    "00www00" ..
    "0w...w0" ..
    "wpmb.mw" ..
    "w.mmbmw" ..
    "wb.bmgw" ..
    "0wmm.w0" ..
    "00www00",

    Obstacles = {true, true, false, false, false, false, false, false}
}

PY_2 = {
    TurnCount = 21,
    Width = 7,
    Height = 7,
    Puzzle =
    "00www00" ..
    "0wb..w0" ..
    "wp.b.mw" ..
    "wmnbb.w" ..
    "ws.mmgw" ..
    "0w.n.w0" ..
    "00www00",

    Obstacles = {true, true, true, false, false, false, false, false}
}

PY_3 = {
    TurnCount = 31,
    Width = 9,
    Height = 9,
    Puzzle =
    "00wwwww00" ..
    "0ws....w0" ..
    "w..mm...w" ..
    "wpbbbmbmw" ..
    "w.mmmb.mw" ..
    "w.m.smbgw" ..
    "w..s..bbw" ..
    "0w.....w0" ..
    "00wwwww00" ,

    Obstacles = {true, true, true, false, false, false, false, false}
}

JA_1 = {
    TurnCount = 26,
    Width = 9,
    Height = 9,
    Puzzle =
    "0wwwwwww0" ..
    "w..np...w" ..
    "wssn....w" ..
    "wk.b.s..w" ..
    "wbb.sss.w" ..
    "w..mbm..w" ..
    "w..blm..w" ..
    "w..mgm..w" ..
    "0wwwwwww0" ,

    Obstacles = {true, true, true, true, false, false, false, false}
}

CS_1 = {
    TurnCount = 13,
    Width = 7,
    Height = 7,
    Puzzle =
    "wwwwwww" ..
    "wpw.wgw" ..
    "w.bvbAw" ..
    "wAbvbvw" ..
    "wvbb.Aw" ..
    "wAvAvvw" ..
    "wwwwwww" ,

    Obstacles = {true, false, false, false, true, false, false, false}
}

CS_2 = {
    TurnCount = 19,
    Width = 7,
    Height = 7,
    Puzzle =
    "wwwwwww" ..
    "wpw.w.w" ..
    "w..bA.w" ..
    "wAv.bbw" ..
    "wvAnm.w" ..
    "w.sn.gw" ..
    "wwwwwww" ,

    Obstacles = {true, true, true, false, true, false, false, false}
}

CP_1 = {
    TurnCount = 6,
    Width = 5,
    Height = 5,
    Puzzle =
    "wwwww" ..
    "wp..w" ..
    "wb3bw" ..
    "w..gw" ..
    "wwwww" ,

    Obstacles = {true, false, false, false, false, true, false, false}
}

CP_2 = {
    TurnCount = 16,
    Width = 9,
    Height = 5,
    Puzzle =
    "wwwwwwwww" ..
    "wp4v....w" ..
    "ws2AvmAlw" ..
    "w.4k..bgw" ..
    "wwwwwwwww" ,

    Obstacles = {true, true, false, true, true, true, false, false}
}

CP_3 = {
    TurnCount = 33,
    Width = 13,
    Height = 5,
    Puzzle =
    "wwwwwwwwwwwww" ..
    "wp.6A5.3.4..w" ..
    "w..5A5.4.6..w" ..
    "w..4v6.3.7.gw" ..
    "wwwwwwwwwwwww" ,

    Obstacles = {false, false, false, false, true, true, false, false}
}

C_1 = {
    TurnCount = 8,
    Width = 7,
    Height = 7,
    Puzzle =
    "wwwwwww" ..
    "wp{...w" ..
    "w..{..w" ..
    "w.{...w" ..
    "w..{..w" ..
    "w.{...w" ..
    "wwwwwww" ,

    Obstacles = {false, false, false, false, false, false, true, false}
}


C_2 = {
    TurnCount = 19,
    Width = 9,
    Height = 9,
    Puzzle =
    "wwwwwwwww" ..
    "wpm{....w" ..
    "wbbbb...w" ..
    "wbbbb...w" ..
    "w.......w" ..
    "w.......w" ..
    "w.......w" ..
    "w......gw" ..
    "wwwwwwwww" ,

    Obstacles = {true, true, false, false, false, false, true, false}
}

RU_1 = {
    TurnCount = 2,
    Width = 7,
    Height = 7,
    Puzzle =
    "0wwwww0" ..
    "wwpo.ww" ..
    "w.....w" ..
    "w.....w" ..
    "w.....w" ..
    "ww.ogww" ..
    "0wwwww0" ,

    Obstacles = {false, false, false, false, false, false, false, true}
}

RU_2 = {
    TurnCount = 8,
    Width = 7,
    Height = 7,
    Puzzle =
    "0wwwww0" ..
    "wwpo.ww" ..
    "w.mbo.w" ..
    "w...bbw" ..
    "w...bmw" ..
    "ww..gww" ..
    "0wwwww0" ,

    Obstacles = {true, true, false, false, false, false, false, true}
}

LU_1 = {
    TurnCount = 15,
    Width = 10,
    Height = 10,
    Puzzle =
    "000wwww000" ..
    "0wwp...ww0" ..
    "0w......w0" ..
    "w........w" ..
    "w........w" ..
    "w........w" ..
    "w........w" .. 
    "0w......w0" ..
    "0ww...gww0" ..
    "000wwww000" ,

    Obstacles = {false, false, false, false, false, false, false, false}
}


