CSS_2 = CreateDialog(function()

    Talk("C#", "정말이지!", "C#_Normal")
    Talk("Java", "곤란하게 하고자 하는 행위는 아닙니다.", "Java_Normal")
    Talk("C#", "그러면 대체 무얼 위해 이러시는 건가요?", "C#_Normal")

    local select = MakeSelect("C#", "그러면 대체 무얼 위해 이러시는 건가요?", "C#_Normal",
    {
        "네 도움이 필요해.",
        "음... 많은 사람의 손길?"
    })
    if select == 0 then
        Talk("C#", "그러면 이런 식으로 나오면 안됐잖아요.", "C#_Normal")
        Talk("C#", "참 이상한 사람이네...", "C#_Normal")

    elseif select == 1 then
        Talk("C#", "농담할 기분 아닙니다.", "C#_Normal")

    end
    Talk("C#", "...", "C#_Normal")
    Talk("C#", "...그래요. 믿어보겠습니다.", "C#_Normal")
    Talk("C#", "도움이 필요한 분을 내치기엔 좀 그렇네요.", "C#_Normal")

end)