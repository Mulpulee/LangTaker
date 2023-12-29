CPP_3 = CreateDialog(function()

    Talk("C++", "뭐야?! 어떻게 여기까지 온 거야!", "C++_Normal")
    Talk("C++", "나가, 나가나가나가!! 너같은 거 꼴보기 싫어!", "C++_Normal")

    local select = MakeSelect("C++", "나가, 나가나가나가!! 너같은 거 꼴보기 싫어!", "C++_Normal",
    {
        "난 너랑 초면이야.",
        "...그래."
    })
    if select == 0 then
        Talk("C++", "누가 몰라?! 꺼져!", "C++_Normal")
        Talk("C++", "아아아아아아 최악이야 최악이야", "C++_Normal")
        Talk("C++", "사라져, 그냥 사라지라고!!", "C++_Normal")
    elseif select == 1 then
        Talk("C++", "......", "C++_Normal")
        Talk("C++", "...뭐, 뭐야 진짜로?", "C++_Normal")
        Talk("C++", "아냐, 안 가도 돼!", "C++_Normal")
        Talk("C++", "에이씨... 너무 심했나.", "C++_Normal")
        Talk("C++", "내가 사람을 오래 만나본 적이 있어야 망정이지.", "C++_Normal")
        Talk("C++", "...", "C++_Normal")
        Talk("C++", "야, 하나 부탁하자.", "C++_Normal")
        Talk("C++", "나도 데려가.", "C++_Normal")
        Talk("C++", "아, 이거 협박이야!!", "C++_Normal")
    end

end)