Python_2 = CreateDialog(function()

    Talk("JavaScript", "아우우우!! 얄미워!!", "JS_Normal")
    Talk("Python", "침입자 탐색. 정당한 일입니다.", "Python_Normal")
    Talk("Python", "이 공간에서 나가주시길 정중히 부탁드리겠습니다.", "Python_Normal")

    local select = MakeSelect("Python", "이 공간에서 나가주시길 정중히 부탁드리겠습니다.", "Phython_Normal",
    {
        "튕기네?",
        "여기 혼자 있는 거 지겨웠잖아?"
    })
    if select == 0 then
        Talk("Python", "마지막 경고를 어김을 판단.", "Python_Normal")
        Talk("Python", "...어쩔 수 없군요.", "Python_Normal")
    elseif select == 1 then
        Talk("Python", "...", "Python_Normal")
        Talk("Python", "마지막 미로를 재구축합니다.", "Python_Normal")
    end

end)