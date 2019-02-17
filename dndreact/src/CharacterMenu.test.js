import CharacterMenu from "./CharacterMenu";
import React from 'react';
import ReactDOM from 'react-dom';

const state = [
    { name: 'Ilin' },
    { name: 'Kagor' },
    { name: 'Bellocke' }
];

describe("CharacterMenu", () => {
    it("renders without crashing", () => {
        const div = document.createElement("div");
        ReactDOM.render(<CharacterMenu characters={state} AddCharacter={() => {}}  />, div);
    });
});