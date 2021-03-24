import React from 'react';

export function ServerErrorSummary(props) {
    return props.message && (
        <div>
            <h4>Server side error:</h4>
            <span style={{ color: "red" }}>{props.message}</span>
        </div>
    )
}