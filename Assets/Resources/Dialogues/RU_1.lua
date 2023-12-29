Ruby_1 = CreateDialog(function()

    Talk("Ruby", "어, 어...", "Ruby_Normal")
    Talk("Ruby", "왜, 왜지... 왜 사람이...", "Ruby_Normal")
    
    local select = MakeSelect("Ruby", "왜, 왜지... 왜 사람이...", "Ruby_Normal",
    {
        "다들 너랑 함께 가려고 왔어.",
        "널 위한 파티를 준비했는데."
    })
    if select == 0 then
        Talk("Ruby", "왜...왜 나랑...?", "Ruby_Normal")
        Talk("Ruby", "나, 난 개성도 없고 평범하고...", "Ruby_Normal")
        Talk("Ruby", "...아, 알았다...", "Ruby_Normal")
        Talk("Ruby", "너도, 너도 그냥 나 놀리려고 온 거지?", "Ruby_Normal")
        Talk("Ruby", "됐어, 그냥... 그냥 가. 가버려...", "Ruby_Normal")

    elseif select == 1 then
        Talk("Ruby", "...", "Ruby_Normal")
        Talk("Ruby", "...파, 파티...?", "Ruby_Normal")
        Talk("Ruby", "나, 나를 위한...?", "Ruby_Normal")
        Talk("Ruby", "하, 한 번 가 볼까...", "Ruby_Normal")

    end

end)