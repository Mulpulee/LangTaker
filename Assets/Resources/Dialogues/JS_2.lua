JS_2 = CreateDialog(function()

    Talk("JavaScript", "생각보다 금방 왔잖아...??", "JS_Normal")
    Talk("JavaScript", "놀라운데...", "JS_Normal")

    local select = MakeSelect("JavaScript", "놀라운데...", "JS_Normal",
    {
        "감동했구나?",
        "이정도는 기본이지."
    })
    Talk("JavaScript", "아하하~ 농담인가? 재밌다.", "JS_Normal")
    Talk("JavaScript", "뭐어~약속은 약속이니까.", "JS_Normal")
    Talk("JavaScript", "하나 물어볼래. 여기 밖으로 나가면 날 봐 줄 사람이 있을까?", "JS_Normal")
    Talk("JavaScript", "나 여기서 혼자 너무 외로웠거든~", "JS_Normal")
    local select = MakeSelect("JavaScript", "나 여기서 혼자 너무 외로웠거든~", "JS_Normal",
    {
        "그럼, 물론이지",
        "없을 걸."
    })
    
    if select == 0 then
        Talk("JavaScript", "... ...", "JS_Normal")
        Talk("JavaScript", "거짓말인거 다 알아!", "JS_Normal")
        EndDialog(false, "JavaScript는 빈말을 하는 타인을 혐오한다.", "JavaScript", 0, "JS_2")
    elseif select == 1 then
        Talk("JavaScript", "그렇지? 아하하...", "JS_Normal")
        Talk("JavaScript", "그럼 하나 부탁하고 싶은 게 있어.", "JS_Normal")
        Talk("JavaScript", "내 옆에서 절대 떨어지지 마! 시선도 돌리지 말고! 알겠어?", "JS_Normal")
        EndDialog(true, "JavaScript는 드디어 자신만을 바라볼 이를 만났다.", "JavaScript", 1, "end")
    end

end)