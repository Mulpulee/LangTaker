Lua_1 = CreateDialog(function()

    Talk("Lua","음~에~ 안녕~","Lua_Normal")
    Talk("Lua","내 잠을 깨운 게 너였구나?","Lua_Normal")
    Talk("Lua","어쩐지 소란스럽다더니~","Lua_Normal")
    Talk("Lua","그럼 질~문! 나는 누구일까요~","Lua_Normal")
    Talk("Lua","...","Lua_Normal")
    Talk("Lua","잠깐! 대답 금지~ 내가 스스로 밝히는 게 좋겠지~","Lua_Normal")
    Talk("Lua","나는 Lua야. 이 미로는 내가 만들었지... 멋지지 않아?","Lua_Normal")
    Talk("Lua","이 미로에 대해 더 알아가고 싶지 않아?","Lua_Normal")
    
    local select = MakeSelect("Lua","이 미로에 대해 더 알아가고 싶지 않아?","Lua_Normal",
    {
        "좋아.",
        "아니, 나 혼자 해결할게."
    })
    if select == 0 then
    Talk("Lua","후후, 탁월한 선택이야...","Lua_Normal")
    Talk("Lua","그럼, 가기 전에 잠을 좀 자 볼까...","Lua_Normal")
        

    elseif select == 1 then
        Talk("Lua","헤에~","Lua_Normal")
        Talk("Lua","그래! 알겠어~","Lua_Normal")
        Talk("Lua","무운을 빌게~","Lua_Normal")


    end

end)