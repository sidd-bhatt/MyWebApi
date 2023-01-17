import { useEffect, useState } from "react";
import axios from 'axios';

const DisplayData = (props) => {
    const [apiData, setApiData] = useState([]);//useState takes data from props and gives it to apidata
    useEffect(
        () => {
            axios.get('http://localhost:5007/api/Students')
                .then(response => { setApiData(response.data) });
        }
    )

    

    var tablerows = apiData.map(obj => {
        return (
            <tr>
                <td>{obj.Sid}</td>
                <td>{obj.Sname}</td>
                <td>{obj.Course}</td>
            </tr>
        );
    });

    return (
        <>
            <br/><br/>
            <table id="studentsTable">
                <tr>
                    <td>StudentId</td>
                    <td>Student Name</td>
                    <td>Course</td>
                </tr>
                {tablerows}
            </table>
        </>
    );

}
export default DisplayData;