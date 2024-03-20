import React, { useState, useEffect } from 'react';

const Home = () => {
    const [state, setState] = useState({

        question: "",
        answers: '',
        rank = 0
        loading: true

    });

    useEffect(() => {
        const populateData = async () => {
            const response = await fetch('/api/home');
            const data = await response.json();

            //console.log(data)
            //data.forEach(x => {

            //});

            //Question:
            const questionNum = 1 // this should be the input

            const qus = data.find(x => x.questionNumber === questionNum).questions;
            const answerAndRank = data.filter(x => x.questionNumber === questionNum)
                            .map(item => ({ answer: item.answer, rank: item.rank }));

            console.log(ans)
            const myAnswer = "Answer 2";

            const ans = myAnswer
            const rank = answerAndRank.find(x => x.answer == myAnswer).rank;








            setState({
                question: qus,
                answers: ans,
                rank: rank,
                loading: false
            });




        }
        populateData();
    }, []);

    const { loading , question, answers, rank} = state;
    const contents = loading ? <div>Loading...</div>
        : <div>Question: {question}?
            <br /> Answer(s): {answers}
            <br /> Rank(s): {rank}</div>;

    return contents
}

export default Home;
