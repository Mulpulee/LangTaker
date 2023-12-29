C_2 = CreateDialog(function()

    Talk("C", "어머, 이걸 성공했다고?", "C_Normal")
    Talk("C", "내가 너무 과소평가했나...", "C_Normal")

    local select = MakeSelect("C", "못 보던 사람이...", "C_Normal",
    {
        "내 매력에 반했나봐?",
        "더 멋진 모습 보여줄 수 있는데."
    })
    if select == 0 then
        Talk("C", "음~ 딱히?", "C_Normal")
        Talk("C", "그게 매력이 될 수 있나?", "C_Normal")
    elseif select == 1 then
        Talk("C", "어머, 정말?", "C_Normal")
        Talk("C", "어떤 식으로?", "C_Normal")
        Talk("C", "...방금 도발한 거라면, 성공적이었다고 해 줄게.", "C_Normal")
        Talk("C", "너에 대해 더 알고싶어졌어.", "C_Normal")
    end

end)