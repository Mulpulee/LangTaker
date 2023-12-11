JS_1 = CreateDialog(function()

    Talk("JavaScript", "우와, 안녕~?! 여긴 무슨 일이야~?", "JS_Normal")
    Talk("JavaScript", "처음 보는 언어인 거 같은데~", "JS_Normal")
    
    local select = MakeSelect("JavaScript", "처음 보는 언어인 거 같은데~", "JS_Normal",
    {
        "난 사람인데.",
        "지금부터 너를 데려갈거야."
    })
    Talk("JavaScript", "아하하~ 농담인가? 재밌다.", "JS_Normal")
    
    Talk("JavaScript", "하나 물어볼래. 여기 밖으로 나가면 날 봐 줄 사람이 있을까?", "JS_Normal")
    Talk("JavaScript", "솔직히 난 확신이 잘 안 서는데...", "JS_Normal")
    local select = MakeSelect("JavaScript", "솔직히 난 확신이 잘 안 서는데...", "JS_Normal",
    {
        "없을 걸.",
        "그럼, 물론이지"
    })
    
    if select == 0 then
        Talk("JavaScript", "그렇지? 아하하...", "JS_Normal")
        Talk("JavaScript", "그럼 하나 부탁하고 싶은 게 있어.", "JS_Normal")
        Talk("JavaScript", "네가 날 봐 줘!", "JS_Normal")
    elseif select == 1 then
        Talk("JavaScript", "... ...", "JS_Normal")
        Talk("JavaScript", "거짓말인거 다 알아!", "JS_Normal")
    end

end)