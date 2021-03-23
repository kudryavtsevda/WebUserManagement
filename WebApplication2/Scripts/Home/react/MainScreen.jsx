import React from 'react';
import { render } from 'react-dom';
import axios from "axios";
import 'materialize-css';
import { Table, Icon, Button } from 'react-materialize';
import {
    BrowserRouter as Router,
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
    }
    render() {

        return (
            <Table>
                <thead>
                    <tr>
                        <th>Action</th>
                        <th data-field="firsname">First Name</th>
                        <th data-field="lastname">Last Name</th>
                        <th data-field="email">Email</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.state.users.map(user => (
                            <tr key={user.Id}>
                                <td><Link to={`/edituser/${user.Id}`} >
                                    <Button icon={<Icon right>update</Icon>} flat node="button" waves="light">
                                        Edit
                                    </Button>
                                </Link></td>
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