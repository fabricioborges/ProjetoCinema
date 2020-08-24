import React, { useEffect, useState, forwardRef } from 'react';
import MaterialTable from 'material-table';
import AddBox from '@material-ui/icons/AddBox';
import ArrowDownward from '@material-ui/icons/ArrowDownward';
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';
import api from '../../../services/api';
import Menu from '../../../components/menu/menu';
import './customer-report.css';

export default function CustomerReport({ history }) {
    const [customerReports, setCustomerReports] = useState([]);

    const columns = [
        { title: 'Cliente', field: 'Name', cellStyle: { padding: '5px', width: '10px' } },
        { title: 'Email', field: 'Email', cellStyle: { padding: '5px', width: '10px' } },
        { title: 'Gastos', field: 'Value', type: 'currency', currencySetting: { currencyCode: 'BRL', minimumFractionDigits: 0, maximumFractionDigits: 2 }, cellStyle: { padding: '5px', width: '10px' } }
    ]

    const tableIcons = {
        Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
        Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
        Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
        Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
        DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
        Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
        Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
        Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
        FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
        LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
        NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
        PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
        ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
        Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
        SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
        ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
        ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
    }

    useEffect(() => {
        async function loadCustomerReports() {
            const response = await api.get('api/report/customerreport');

            setCustomerReports(response.data);
        }

        loadCustomerReports();
    }, [])

    return (
        <div id="App">
            <Menu {...history} />
            <div className="customer-report-container-view">
                {customerReports.length > 0 ?
                    (<MaterialTable
                        title="Relatório de Clientes"
                        columns={columns}
                        data={customerReports}
                        style={{
                            maxHeight: "500px"
                        }}
                        options={{ pageSize: 10 }}
                        icons={tableIcons}
                    />
                    ) : 'Não há relatórios para serem gerados :('}
            </div>

        </div>
    )
}