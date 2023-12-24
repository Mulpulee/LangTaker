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


test = {
    TurnCount = 22,
    Width = 10,
    Height = 5,
    Puzzle =
    "wwwwwwwwww" ..
    "w12345678w" ..
    "wo.{.....w" ..
    "w9....o.pw" ..
    "wwwwwwwwww"
}

SpecialPattern = {
    Pattern1 = {true, true, true, false}
}