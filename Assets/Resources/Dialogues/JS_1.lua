JS_1 = CreateDialog(function()

    Talk("JavaScript", "우왁! 뭐야!", "JS_Normal")
    Talk("JavaScript", "...", "JS_Normal")
    Talk("JavaScript", "아, 아하하... 안녕~ 넌 누구야?", "JS_Normal")

    local select = MakeSelect("JavaScript", "아, 아하하... 안녕~ 넌 누구야?", "JS_Normal",
    {
        "나는 나지.",
        "난 이 컴퓨터의 주인이야."
    })
    Talk("JavaScript", "그게 뭐야~ 너 웃긴다?", "JS_Normal")
    Talk("JavaScript", "난 JS라고 해! 이 미로에서 줄곧 널 지켜봤지.", "JS_Normal")
    Talk("JavaScript", "이렇게 단숨에 도달할 줄 몰랐는데?", "JS_Normal")

    local select = MakeSelect("JavaScript", "이렇게 단숨에 도달할 줄 몰랐는데?", "JS_Normal",
    {
        "아무렴.",
        "죽여주지?"
    })
    
    Talk("JavaScript", "아하하~ 그래~", "JS_Normal")
    Talk("JavaScript", "오랜만에 외부인이라 나도 심술 좀 부려볼까?", "JS_Normal")
    Talk("JavaScript", "다음 미로에서도 날 따라잡으면, 내가 생각해볼게!", "JS_Normal")
    Talk("JavaScript", "어디 한 번 힘내봐!", "JS_Normal")

    EndDialog(false, nil, "JavaScript", 0.5, "JS_2")

end)