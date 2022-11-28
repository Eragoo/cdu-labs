import React, { useState } from 'react';
import './App.css';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { Field } from './getField';
import { createPopulation } from './getPopulation';
import { passDay } from './passDay';

function App() {

  const [x, setX] = useState(50);
  const [y, setY] = useState(50);
  const [karasCount, setKarasCount] = useState(100);
  const [karasOld, setKarasOld] = useState(2);
  const [karasReproduct, setKarasReproduct] = useState(3);
  const [shchukaCount, setShchukaCount] = useState(20);
  const [shchukaOld, setShchukaOld] = useState(5);
  const [shchukaReproduct, setShchukaReproduct] = useState(4);
  const [shchukaDied, setShchukaDied] = useState(5);

  const onChangeX = (event) => {
    setX(event.target.value);
  }

  const onChangeY = (event) => {
    setY(event.target.value);
  }

  const onChangeKarasCount = (event) => {
    setKarasCount(event.target.value);
  }

  const onChangeKarasOld = (event) => {
    setKarasOld(event.target.value);
  }

  const onChangeKarasReproduct = (event) => {
    setKarasReproduct(event.target.value);
  }

  const onChangeShchukaCount = (event) => {
    setShchukaCount(event.target.value);
  }

  const onChangeShchukaOld = (event) => {
    setShchukaOld(event.target.value);
  }

  const onChangeShchukaReproduct = (event) => {
    setShchukaReproduct(event.target.value);
  }

  const onChangeShchukaDied = (event) => {
    setShchukaDied(event.target.value);
  }

  const [day, setDay] = useState(1);

  const [population, setPopulation] = useState(createPopulation(x, y, karasCount, shchukaCount, karasReproduct, shchukaReproduct));

  const nextDay = () => {
    setDay(day + 1);
    const temp = passDay(population, karasReproduct, shchukaReproduct, shchukaDied);
  }

  Field(x, y, population);


  return (
    <div className="App">
      <div className='inputValues'>
        <TextField type="number" id="outlined-basic" label="Розмір по х" variant="outlined" onChange={onChangeX} value={x} />
        <TextField type="number" id="outlined-basic" label="Розмір по y" variant="outlined" onChange={onChangeY} value={y} />
        <TextField type="number" id="outlined-basic" label="К-ть ж" variant="outlined" onChange={onChangeKarasCount} value={karasCount} />
        <TextField type="number" id="outlined-basic" label="Початок розмнож ж" variant="outlined" onChange={onChangeKarasOld} value={karasOld} />
        <TextField type="number" id="outlined-basic" label="Період розмнож ж" variant="outlined" onChange={onChangeKarasReproduct} value={karasReproduct} />
        <TextField type="number" id="outlined-basic" label="К-ть х" variant="outlined" onChange={onChangeShchukaCount} value={shchukaCount} />
        <TextField type="number" id="outlined-basic" label="Початок розмнож х" variant="outlined" onChange={onChangeShchukaOld} value={shchukaOld} />
        <TextField type="number" id="outlined-basic" label="Період розмнож х" variant="outlined" onChange={onChangeShchukaReproduct} value={shchukaReproduct} />
        <TextField type="number" id="outlined-basic" label="Хижак живе без їжі" variant="outlined" onChange={onChangeShchukaDied} value={shchukaDied} />
      </div>
      <div onClick={nextDay}>
        <Button variant="outlined" color="primary">
          вперед
        </Button>
        <br></br>
        День: {day}
      </div>
    </div>
  );
}

export default App;
