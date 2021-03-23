import React from 'react';
import { render } from 'react-dom';
import axios from "axios";
import 'materialize-css';
import { Table } from 'react-materialize';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import DataService from './DataService'

export class MainScreen extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            users: Array(0),
        }
    }

    componentDidMount() {
        DataService.getAll().then((response) => {
            this.setState({ users: response.data });
        });
        /*axios.get('https://localhost:44397/api/users/')
            .then((response) => {
                this.setState({ users: response.data });
            });*/
    }
    render() {

        return (
            <Table>
                <thead>
                    <tr>
                        <th data-field="id">Id</th>
                        <th data-field="firsname">First Name</th>
                        <th data-field="lastname">Last Name</th>
                        <th data-field="email">Email</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.state.users.map(user => (
                            <tr key={user.Id}>
                                <td><Link to={`/edituser/${user.Id}`}>EDIT</Link></td>
                                <td>{user.FirstName}</td>
                                <td>{user.LastName}</td>
                                <td>{user.Email}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
        );
    }
}